namespace PawHavenApp.BusinessLogic.Interfaces;

using System.Security.Claims;
using PawHavenApp.BusinessLogic.Models;

public interface IJwtService
{
    string GenerateAccessToken(UserModel userModel);

    string GenerateRefreshToken();

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}