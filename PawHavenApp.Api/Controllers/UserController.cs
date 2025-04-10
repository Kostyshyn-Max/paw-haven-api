namespace PawHavenApp.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.Api.ViewModels;
using PawHavenApp.BusinessLogic.Models;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]/")]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<UserTokenData>> Register([FromBody] UserCreateViewModel user)
    {
        return new UserTokenData();
    }
}