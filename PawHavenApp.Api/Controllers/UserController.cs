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
    private readonly IJwtService jwtService;
    private readonly IUserService userService;
    private readonly IMapper mapper;

    public UserController(IJwtService jwtService, IUserService userService, IMapper mapper)
    {
        this.jwtService = jwtService;
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
    public ActionResult<UserTokenDataModel> Refresh([FromBody] UserRefreshTokenViewModel tokenModel)
    {
        var principals = this.jwtService.GetPrincipalFromExpiredToken(tokenModel.OldToken);
        if (principals is null)
        {
            return this.BadRequest();
        }

        var user = new UserModel()
        {
            Id = Guid.Parse(principals.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
                            string.Empty),
            FirstName = principals.Claims?.FirstOrDefault(c => c.Type == "firstName")?.Value ?? string.Empty,
            LastName = principals.Claims?.FirstOrDefault(c => c.Type == "lastName")?.Value ?? string.Empty,
            Email = principals.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty,
            RoleId = (int)UserRoles.User,
        };

        var token = this.jwtService.GenerateAccessToken(user);
        var refreshToken = this.jwtService.GenerateRefreshToken();

        return new UserTokenDataModel
        {
            Token = token,
            RefreshToken = refreshToken,
        };
    }
}