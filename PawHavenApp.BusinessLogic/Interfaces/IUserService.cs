namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;

public interface IUserService
{
    Task<Guid?> RegisterUserAsync(UserCreateModel user);

    Task<UserTokenDataModel?> LoginAsync(UserLoginModel user);
}