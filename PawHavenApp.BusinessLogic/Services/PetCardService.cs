namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using Microsoft.Extensions.Logging;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class PetCardService : IPetCardService
{
    private readonly IPetCardRepository petCardRepository;
    private readonly IS3StorageService s3StorageService;
    private readonly IOrganisationService organisationService;
    private readonly IUserService userService;
    private readonly IMapper mapper;
    private readonly ILogger<PetCardService> logger;

    public PetCardService(
        ApplicationDbContext context,
        IS3StorageService s3StorageService,
        IOrganisationService organisationService,
        IUserService userService,
        IMapper mapper,
        ILogger<PetCardService> logger)
    {
        this.petCardRepository = new PetCardRepository(context);
        this.s3StorageService = s3StorageService;
        this.organisationService = organisationService;
        this.userService = userService;
        this.mapper = mapper;
        this.logger = logger;
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

    public async Task<List<PetCardModel>> GetPetCardsByOwnerAsync(Guid ownerId)
    {
        var petCardEntities = await this.petCardRepository.GetAllAsync(p => p.OwnerId == ownerId);
        return petCardEntities.Select(e => this.mapper.Map<PetCardModel>(e)).ToList();
    }

    public async Task<bool> DeletePetCardAsync(Guid ownerId, int cardId)
    {
        var petCard = await this.petCardRepository.GetByIdAsync(cardId);

        if (petCard is null || !petCard.OwnerId.Equals(ownerId))
        {
            return false;
        }

        foreach (var petPhoto in petCard.Photos)
        {
            var result = await this.s3StorageService.DeleteFile(petPhoto.PetPhotoLink);

            if (!result)
            {
                return false;
            }
        }

        await this.petCardRepository.DeleteAsync(petCard);
        return true;
    }

    public async Task<bool> ChangeOwnerAsync(ChangePetCardOwnerModel model)
    {
        var petCard = await this.petCardRepository.GetByIdAsync(model.PetCardId);
        if (petCard is null)
        {
            return false;
        }

        var organisation = await this.organisationService.GetByIdAsync(model.OrganisationId);
        if (organisation is null)
        {
            return false;
        }

        petCard.User = null;
        petCard.OwnerId = organisation.OwnerId;
        petCard.User = new User() { Id = organisation.OwnerId };

        await this.petCardRepository.UpdateAsync(petCard);

        return true;
    }
}