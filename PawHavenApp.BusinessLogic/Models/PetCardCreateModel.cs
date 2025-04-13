namespace PawHavenApp.BusinessLogic.Models;

using Microsoft.AspNetCore.Http;

public class PetCardCreateModel
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public string Health { get; set; }

    public string Gender { get; set; }

    public int HealthStatusId { get; set; }

    public int PetTypeId { get; set; }

    public ICollection<IFormFile> Photos { get; set; }
}