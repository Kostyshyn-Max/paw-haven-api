namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public interface IPetCardService
{
    Task<int?> CreatePetCardAsync(PetCardModel petCard);

    Task<List<PetCardModel>> GetAllPetCardsAsync();

    Task<List<PetCardModel>> GetAllPetCardsAsync(int page, int pageSize);

    Task<PetCardModel?> GetPetCardDetailsByIdAsync(int petCardId);

    Task<List<PetCardModel>> GetPetCardsByOwnerAsync(Guid ownerId);

    Task<bool> DeletePetCardAsync(Guid ownerId, int cardId);
}