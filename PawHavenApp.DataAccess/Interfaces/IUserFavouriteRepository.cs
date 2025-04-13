namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IUserFavouriteRepository : ICrudRepository<UserFavourite, int>
{
    Task<UserFavourite?> GetByIdAsync(int petCardId, Guid userId);

    Task DeleteAsync(int petCardId, Guid userId);
}