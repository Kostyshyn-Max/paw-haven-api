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
    private readonly IMapper mapper;

    public OrganisationService(ApplicationDbContext context, IMapper mapper)
    {
        this.organisationRepository = new OrganisationRepository(context);
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
}