namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("chats")]
public class Chat : AbstractEntity<int>
{
    [Column("user_id")]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; }

    [Column("organisation_id")]
    [ForeignKey(nameof(Organisation))]
    public int OrganisationId { get; set; }

    public Organisation Organisation { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}
