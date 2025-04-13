namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Repositories;

public class PetStoryService : IPetStoryService
{
    private readonly IMapper mapper;
    private readonly PetStoryRepository petStoryRepository;

    public PetStoryService(ApplicationDbContext context, IMapper mapper)
    {
        this.petStoryRepository = new PetStoryRepository(context);
        this.mapper = mapper;
    }

    public async Task<int?> CreatePetStoryAsync(PetStoryModel petStory)
    {
        var petStoryEntity = this.mapper.Map<PetStory>(petStory);
        return await this.petStoryRepository.CreateAsync(petStoryEntity);
    }

    public async Task<List<PetStoryModel>> GetAllPetStoriesAsync()
    {
        var petStoriesEntities = await this.petStoryRepository.GetAllAsync();
        return petStoriesEntities.Select(e => this.mapper.Map<PetStoryModel>(e)).ToList();
    }

    public async Task<List<PetStoryModel>> GetAllPetStoriesAsync(int page, int pageSize)
    {
        var petStoriesEntities = await this.petStoryRepository.GetAllAsync(page, pageSize);
        return petStoriesEntities.Select(e => this.mapper.Map<PetStoryModel>(e)).ToList();
    }
}
