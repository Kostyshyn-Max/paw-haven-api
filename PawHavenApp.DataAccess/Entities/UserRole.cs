namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("user_roles")]
public class UserRole : AbstractEntity<int>
{
    [Column("name")] 
    public string Name { get; set; } = string.Empty;
}

public enum UserRoles
{
    Admin = 1,
    User = 2,
    OrganisationOwner = 3,
}