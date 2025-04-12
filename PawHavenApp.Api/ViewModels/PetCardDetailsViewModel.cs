namespace PawHavenApp.Api.ViewModels;

using PawHavenApp.BusinessLogic.Models;

public class PetCardDetailsViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Location { get; set; }

    public string Description { get; set; }

    public string Health { get; set; }

    public int Views { get; set; }

    public PetTypeModel PetType { get; set; }

    public HealthStatusModel HealthStatus { get; set; }

    public ICollection<PetPhotoViewModel> Photos { get; set; }

    public UserProfileViewModel User { get; set; }
}