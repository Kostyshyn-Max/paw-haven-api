namespace PawHavenApp.Api.ViewModels;

using System.ComponentModel.DataAnnotations;

public class UserCreateViewModel
{
    [Required]
    [RegularExpression(@"^\w{5,100}$")]
    public string FirstName { get; set; }

    [Required]
    [RegularExpression(@"^\w{5,100}$")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public bool IsOrganisationOwner { get; set; } = false;

    [Required]
    public string Password { get; set; }
}