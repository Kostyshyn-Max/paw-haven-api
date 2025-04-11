namespace PawHavenApp.BusinessLogic.Models;

public class UserModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsOrganisationOwner { get; set; }

    public int RoleId { get; set; }

    public OrganisationModel? Organisation { get; set; }
}