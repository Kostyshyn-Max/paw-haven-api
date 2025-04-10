namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pet_stories")]
public class PetStory : AbstractEntity<int>
{
    [Required]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("likes")]
    public int Likes { get; set; }

    [Column("author_id")]
    [ForeignKey(nameof(User))]
    public Guid AuthorId { get; set; }

    public User User { get; set; }

    [Column("photo_link")]
    public string? Link { get; set; }
}
