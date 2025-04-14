namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public interface IUserService
{
    Task<Guid?> RegisterUserAsync(UserCreateModel user);

    Task<UserTokenDataModel?> LoginAsync(UserLoginModel user);

    Task<UserTokenDataModel?> RefreshToken(UserTokenDataModel tokenModel);

    Task<UserModel?> GetUserProfile(Guid userId);

    Task<bool> UpdateUserProfileAsync(UserUpdateModel user);
}