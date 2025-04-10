namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pet_photos")]
public class PetPhoto : AbstractEntity<int>
{
    [Required]
    [Column("pet_photo_link")]
    public string PetPhotoLink { get; set; } = string.Empty;

    [Column("pet_card_id")]
    [ForeignKey(nameof(PetCard))]
    public int PetCardId { get; set; }

    public PetCard PetCard { get; set; }
}
