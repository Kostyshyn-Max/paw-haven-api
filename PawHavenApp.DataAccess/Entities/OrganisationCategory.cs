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

public enum OrganisationCategories
{
    VetClinic = 1,
    Shelter = 2,
    Nursery = 3,
}