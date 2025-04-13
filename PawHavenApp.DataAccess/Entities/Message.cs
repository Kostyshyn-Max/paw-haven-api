namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("messages")]
public class Message : AbstractEntity<int>
{
    [Required]
    [Column("message_text")]
    public string MessageText { get; set; } = string.Empty;

    [Column("chat_id")]
    [ForeignKey(nameof(Chat))]
    public int ChatId { get; set; }

    public Chat Chat { get; set; }

    [Column("sender_id")]
    [ForeignKey(nameof(User))]
    public Guid SenderId { get; set; }

    public User User { get; set; }
}
