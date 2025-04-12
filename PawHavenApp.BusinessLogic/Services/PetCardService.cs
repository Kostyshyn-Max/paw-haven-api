namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class PetCardService : IPetCardService
{
    private readonly PetCardRepository petCardRepository;

    private readonly IMapper mapper;

    public PetCardService(ApplicationDbContext context, IMapper mapper)
    {
        this.petCardRepository = new PetCardRepository(context);
        this.mapper = mapper;
    }

    public async Task<int?> CreatePetCardAsync(PetCardModel petCard)
    {
        var petCardEntity = this.mapper.Map<PetCard>(petCard);
        return await this.petCardRepository.CreateAsync(petCardEntity);
    }

    public async Task<List<PetCardModel>> GetAllPetCardsAsync()
    {
        var petCardEntities = await this.petCardRepository.GetAllAsync();
        return petCardEntities.Select(e => this.mapper.Map<PetCardModel>(e)).ToList();
    }

    public async Task<List<PetCardModel>> GetAllPetCardsAsync(int page, int pageSize)
    {
        var petCardEntities = await this.petCardRepository.GetAllAsync(page, pageSize);
        return petCardEntities.Select(e => this.mapper.Map<PetCardModel>(e)).ToList();
    }

    public async Task<PetCardModel?> GetPetCardDetailsByIdAsync(int petCardId)
    {
        var petCard = await this.petCardRepository.GetByIdAsync(petCardId);
        if (petCard is null)
        {
            return null;
        }

        petCard.Views += 1;
        await this.petCardRepository.UpdateAsync(petCard);

        return this.mapper.Map<PetCardModel>(petCard);
    }
}