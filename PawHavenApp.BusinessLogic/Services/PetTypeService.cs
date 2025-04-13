namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class PetTypeService : IPetTypeService
{
    private readonly IPetTypeRepository petTypeRepository;
    private readonly IMapper mapper;

    public PetTypeService(ApplicationDbContext context,  IMapper mapper)
    {
        this.petTypeRepository = new PetTypeRepository(context);
        this.mapper = mapper;
    }

    public async Task<IEnumerable<PetTypeModel>> GetPetTypesAsync()
    {
        var petTypes = await this.petTypeRepository.GetAllAsync();
        return petTypes.Select(t => this.mapper.Map<PetTypeModel>(t));
    }
}