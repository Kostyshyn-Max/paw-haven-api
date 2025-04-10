﻿namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User : AbstractEntity<Guid>
{
    [Column("role_id")]
    [ForeignKey(nameof(UserRole))]
    public int RoleId { get; set; }

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
    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    [Column("password_salt")]
    public string PasswordSalt { get; set; } = string.Empty;

    [Required]
    [Column("is_organisation_owner")]
    public bool IsOrganisationOwner { get; set; }

    [Required]
    [Column("refresh_token")]
    public string RefreshToken { get; set; }

    [Required]
    [Column("refresh_token_expire_date")]
    public DateTime RefreshTokenExpireDate { get; set; }

    [Required]
    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }

    public UserRole UserRole { get; set; }
}
