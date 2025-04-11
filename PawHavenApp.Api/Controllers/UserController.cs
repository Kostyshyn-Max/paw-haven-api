namespace PawHavenApp.Api.Controllers;

using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.Api.ViewModels;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]/")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IMapper mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserTokenDataModel>> Login([FromBody] UserLoginViewModel user)
    {
        UserTokenDataModel? tokenModel = await this.userService.LoginAsync(this.mapper.Map<UserLoginModel>(user));
        if (tokenModel is null)
        {
            return this.Unauthorized("Invalid username or password.");
        }

        return this.Ok(tokenModel);
    }

    [HttpPost("register/user")]
    public async Task<ActionResult<UserTokenDataModel>> Register([FromBody] UserCreateViewModel user)
    {
        await this.userService.RegisterUserAsync(this.mapper.Map<UserCreateModel>(user));
        UserTokenDataModel? tokenModel = await this.userService.LoginAsync(new UserLoginModel
        {
            Email = user.Email,
            Password = user.Password,
        });

        if (tokenModel is null)
        {
            return this.BadRequest("Registration Failed");
        }

        return this.Ok(tokenModel);
    }

    [HttpPost("register/organisation")]
    public async Task<ActionResult<UserTokenDataModel>> Register([FromBody] OrganisationCreateViewModel organisation)
    {
        return new UserTokenDataModel();
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<UserTokenDataModel>> Refresh([FromBody] UserRefreshTokenViewModel oldTokenModel)
    {
        var tokenModel = await this.userService.RefreshToken(new UserTokenDataModel
        {
            Token = oldTokenModel.OldToken,
            RefreshToken = oldTokenModel.RefreshToken,
        });
        if (tokenModel is null)
        {
            return this.BadRequest("Refresh Failed");
        }

        return this.Ok(tokenModel);
    }
}