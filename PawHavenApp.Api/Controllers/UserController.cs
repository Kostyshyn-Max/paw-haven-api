namespace PawHavenApp.Api.Controllers;

using System.Security.Claims;
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

    public UserController(IJwtService jwtService)
    {
        this.jwtService = jwtService;
    }

    [HttpPost("login")]
    public ActionResult<UserTokenDataModel> Login([FromBody] UserLoginViewModel user)
    {
        var token = this.jwtService.GenerateAccessToken(new UserModel()
        {
            FirstName = "John", LastName = "Doe", Email = user.Email, Id = Guid.NewGuid(), RoleId = (int)UserRoles.User,
        });
        var refreshToken = this.jwtService.GenerateRefreshToken();

        return this.Ok(new UserTokenDataModel
        {
            Token = token,
            RefreshToken = refreshToken,
        });
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserTokenDataModel>> Register([FromBody] UserCreateViewModel user)
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