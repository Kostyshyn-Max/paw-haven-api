namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class OrganisationService : IOrganisationService
{
    private readonly IOrganisationRepository organisationRepository;
    private readonly IPetCardRepository petCardRepository;
    private readonly IMapper mapper;

    public OrganisationService(ApplicationDbContext context, IMapper mapper)
    {
        this.organisationRepository = new OrganisationRepository(context);
        this.petCardRepository = new PetCardRepository(context);
        this.mapper = mapper;
    }

    public async Task<int?> CreateAsync(OrganisationCreateModel organisation, Guid userId)
    {
        Organisation? organisationEntity = this.mapper.Map<Organisation>(organisation);
        if (organisationEntity is null)
        {
            return null;
        }

        organisationEntity.OwnerId = userId;

        return await this.organisationRepository.CreateAsync(organisationEntity);
    }

    public async Task<IEnumerable<OrganisationModel>> GetAllAsync()
    {
        var organisations = await this.organisationRepository.GetAllAsync();
        var organisationModels = this.mapper.Map<IEnumerable<OrganisationModel>>(organisations);

        foreach (var org in organisationModels)
        {
            var petCards = await this.petCardRepository.GetAllAsync(pc => pc.OwnerId == org.OwnerId);
            org.PetCards = this.mapper.Map<ICollection<PetCardModel>>(petCards);
        }

        return organisationModels;
    }

    public async Task<OrganisationModel?> GetByIdAsync(int id)
    {
        var organisation = await this.organisationRepository.GetByIdAsync(id);
        if (organisation == null)
        {
            return null;
        }

        var organisationModel = this.mapper.Map<OrganisationModel>(organisation);
        var petCards = await this.petCardRepository.GetAllAsync(pc => pc.OwnerId == organisation.OwnerId);
        organisationModel.PetCards = this.mapper.Map<ICollection<PetCardModel>>(petCards);

        return organisationModel;
    }
}