namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("user_favourites")]
public class UserFavourite : AbstractEntity<int>
{
    [Column("user_id")]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; }

    [Column("pet_card_id")]
    [ForeignKey(nameof(PetCard))]
    public int PetCardId { get; set; }

    public PetCard PetCard { get; set; }
}
