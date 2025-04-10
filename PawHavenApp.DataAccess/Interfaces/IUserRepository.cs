namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IUserRepository : ICrudRepository<User, Guid>
{
}