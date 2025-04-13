namespace PawHavenApp.BusinessLogic.Models;

public class UserCreateModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; } = string.Empty;

    public bool IsOrganisationOwner { get; set; }
}