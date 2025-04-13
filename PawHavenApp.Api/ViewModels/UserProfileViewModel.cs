namespace PawHavenApp.Api.ViewModels;

using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public class UserProfileViewModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsOrganisationOwner { get; set; }

    public OrganisationModel? Organisation { get; set; }
}