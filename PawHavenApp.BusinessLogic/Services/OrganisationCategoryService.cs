namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class OrganisationCategoryService : IOrganisationCategoryService
{
    private readonly IOrganisationCategoryRepository organisationCategoryRepository;

    private readonly IMapper mapper;

    public OrganisationCategoryService(ApplicationDbContext context, IMapper mapper)
    {
        this.organisationCategoryRepository = new OrganisationCategoryRepository(context);
        this.mapper = mapper;
    }

    public async Task<IEnumerable<OrganisationCategoryModel>> GetAllCategoriesAsync()
    {
        var categories = await this.organisationCategoryRepository.GetAllAsync();
        return categories.Select(c => this.mapper.Map<OrganisationCategoryModel>(c));
    }
}