namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;

public interface IPetTypeService
{
    Task<IEnumerable<PetTypeModel>> GetPetTypesAsync();
}