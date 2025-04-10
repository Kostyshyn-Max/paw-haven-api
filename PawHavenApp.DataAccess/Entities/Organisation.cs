namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("organisations")]
public class Organisation : AbstractEntity<int>
{
    [Column("owner_id")]
    [ForeignKey(nameof(User))]
    public Guid OwnerId { get; set; }

    public User User { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("donation_credentials")]
    public string? DonationCredentials { get; set; }

    [Column("organisation_category_id")]
    [ForeignKey(nameof(OrganisationCategory))]
    public int OrganisationCategoryId { get; set; }

    public OrganisationCategory OrganisationCategory { get; set; }
}
