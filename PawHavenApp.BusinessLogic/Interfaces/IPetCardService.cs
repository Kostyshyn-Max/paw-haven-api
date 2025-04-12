namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public interface IPetCardService
{
    Task<int?> CreatePetCardAsync(PetCardModel petCard);

    Task<List<PetCardModel>> GetAllPetCardsAsync();

    Task<List<PetCardModel>> GetAllPetCardsAsync(int page, int pageSize);
}