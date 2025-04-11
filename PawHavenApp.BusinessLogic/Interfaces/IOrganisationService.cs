namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;

public interface IOrganisationService
{
    Task<int?> CreateAsync(OrganisationCreateModel organisation);
}