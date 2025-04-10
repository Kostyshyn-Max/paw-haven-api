namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User : AbstractEntity
{
    [Required]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("password_hasр")]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    [Column("password_salt")]
    public string PasswordSalt { get; set; } = string.Empty;

    [Required]
    [Column("organisation_owner")]
    public bool OrganisationOwner { get; set; }

    [Required]
    [Column("refresh_token")]
    public string RefreshToken { get; set; }

    [Required]
    [Column("refresh_token_expire_date")]
    public DateTime RefreshTokenExpireDate { get; set; }

    [Required]
    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }
}
