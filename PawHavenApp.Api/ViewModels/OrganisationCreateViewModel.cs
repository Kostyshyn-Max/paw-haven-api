namespace PawHavenApp.Api.ViewModels;

using PawHavenApp.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

public class OrganisationCreateViewModel
{
    public UserCreateViewModel User { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public string? DonationCredentials { get; set; }

    public string? Location { get; set; }

    public int OrganisationCategoryId { get; set; }
}