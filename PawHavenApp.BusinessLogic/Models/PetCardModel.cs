namespace PawHavenApp.BusinessLogic.Models;

using PawHavenApp.DataAccess.Entities;

public class PetCardModel
{
    public Guid OwnerId { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public string Health { get; set; }

    public int HealthStatusId { get; set; }

    public int PetTypeId { get; set; }

    public int Views { get; set; } = 0;

    public ICollection<PetPhotoModel> Photos { get; set; }

    public HealthStatusModel HealthStatus { get; set; }

    public PetTypeModel PetType { get; set; }

    public UserModel User { get; set; }
}