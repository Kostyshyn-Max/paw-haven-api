namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class AbstractEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
}