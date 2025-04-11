namespace PawHavenApp.Api.ViewModels;

using System.ComponentModel.DataAnnotations;

public class OrganisationCreateViewModel
{
    public UserCreateViewModel User { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public string DonationCredentials { get; set; }
}