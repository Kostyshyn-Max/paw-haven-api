namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public interface IUserFavouritesService
{
    Task<int?> CreateAsync(int petCardId, Guid userId);

    Task DeleteAsync(int petCardId, Guid userId);

    Task<List<PetCardModel>> GetAllFavouritesByUser(Guid userId);

    Task<bool> IsFavouriteExists(int petCardId, Guid Id);
}