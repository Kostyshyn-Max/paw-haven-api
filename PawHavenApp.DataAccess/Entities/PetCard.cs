namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pet_cards")]
public class PetCard : AbstractEntity<int>
{
    [Column("owner_id")]
    [ForeignKey(nameof(User))]
    public Guid OwnerId { get; set; }

    public User User { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("age")]
    public int Age { get; set; }

    [Required]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Column("location")]
    public string Location { get; set; } = string.Empty;

    [Required]
    [Column("health")]
    public string Health { get; set; } = string.Empty;

    [Column("health_status_id")]
    [ForeignKey(nameof(HealthStatus))]
    public int HealthStatusId { get; set; }

    public HealthStatus HealthStatus { get; set; }

    [Column("pet_type_id")]
    [ForeignKey(nameof(PetType))]
    public int PetTypeId { get; set; }

    public PetType PetType { get; set; }

    [Required]
    [Column("views")]
    public int Views { get; set; }
}
