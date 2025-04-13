namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pet_types")]
public class PetType : AbstractEntity<int>
{
    [Required]
    [Column("title")]
    public string Title { get; set; } = string.Empty;
}

public enum PetTypes
{
    Cat = 1,
    Dog = 2,
    Reptile = 3,
    Other = 4,
}