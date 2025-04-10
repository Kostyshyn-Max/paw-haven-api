namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("organisations")]
public class Organisation : AbstractEntity<int>
{
    public int OwnerId { get; set; }
}
