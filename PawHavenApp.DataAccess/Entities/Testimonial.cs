namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("testimonials")]
public class Testimonial : AbstractEntity<int>
{
    [Required]
    [Column("message")]
    public string Message { get; set; } = string.Empty;

    [Column("author_id")]
    [ForeignKey(nameof(User))]
    public Guid AuthorId { get; set; }

    public User User { get; set; }

    [Column("organisation_id")]
    [ForeignKey(nameof(Organisation))]
    public int OrganisationID { get; set; }

    public Organisation Organisation { get; set; }

    [Required]
    [Column("posted_date")]
    public DateTime PostedDate { get; set; }

    [Required]
    [Column("rate")]
    public int Rate { get; set; }
}