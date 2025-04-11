namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User : AbstractEntity<Guid>
{
    [Column("role_id")]
    [ForeignKey(nameof(UserRole))]
    public int RoleId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("password_salt")]
    public string PasswordSalt { get; set; } = string.Empty;

    [Column("is_organisation_owner")]
    public bool IsOrganisationOwner { get; set; }

    [Column("refresh_token")]
    public string? RefreshToken { get; set; }

    [Column("refresh_token_expire_date")]
    public DateTime? RefreshTokenExpireDate { get; set; }

    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }

    public UserRole UserRole { get; set; }

    public Organisation? Organisation { get; set; }
}
