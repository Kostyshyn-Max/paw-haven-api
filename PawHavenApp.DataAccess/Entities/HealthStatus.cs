namespace PawHavenApp.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("health_statuses")]
public class HealthStatus : AbstractEntity<int>
{
    [Required]
    [Column("title")]
    public string Title { get; set; } = string.Empty;
}

public enum HealthStatuses
{
    Healthy = 1,
    Rehabilitated = 2,
    NeedsTreatment = 3,
    Recovering = 4,
    Critical = 5
}