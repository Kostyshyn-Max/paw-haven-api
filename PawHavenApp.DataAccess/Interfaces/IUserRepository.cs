namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IUserRepository : ICrudRepository<User, Guid>
{
    Task<string?> GetUserSalt(string email);

    Task<User?> LoginAsync(string email, string passwordHash);

    Task<string?> GetRefreshToken(Guid userId);

    Task<string?> SetRefreshToken(Guid userId, string refreshToken, DateTime expireDate);
}