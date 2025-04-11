namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("organisation_categories")]
public class OrganisationCategory : AbstractEntity<int>
{
    [Required]
    [Column("title")]
    public string Title { get; set; } = string.Empty;
}