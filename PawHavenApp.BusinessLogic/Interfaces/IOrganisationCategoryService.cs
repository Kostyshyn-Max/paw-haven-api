namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public interface IOrganisationCategoryService
{
    Task<IEnumerable<OrganisationCategoryModel>> GetAllCategoriesAsync();
}