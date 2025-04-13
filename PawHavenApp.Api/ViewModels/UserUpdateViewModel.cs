namespace PawHavenApp.Api.ViewModels;

using System.ComponentModel.DataAnnotations;

public class UserUpdateViewModel
{
    public Guid Id { get; set; }

    [Required]
    [RegularExpression(@"^\w{5,100}$")]
    public string FirstName { get; set; }

    [Required]
    [RegularExpression(@"^\w{5,100}$")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}