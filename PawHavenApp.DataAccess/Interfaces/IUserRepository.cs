namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IUserRepository : ICrudRepository<User, Guid>
{
    Task<string?> GetUserSalt(string email);

    Task<User?> LoginAsync(string email, string passwordHash);
}