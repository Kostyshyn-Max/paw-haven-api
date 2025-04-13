namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;

public interface IPetStoryService
{
    Task<int?> CreatePetStoryAsync(PetStoryModel petStoryModel);

    Task<List<PetStoryModel>> GetAllPetStoriesAsync();

    Task<List<PetStoryModel>> GetAllPetStoriesAsync(int page, int pageSize);
}
