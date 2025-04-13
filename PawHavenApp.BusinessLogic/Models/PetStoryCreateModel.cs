namespace PawHavenApp.BusinessLogic.Models;

using Microsoft.AspNetCore.Http;

public class PetStoryCreateModel
{
    public string Title { get; set; }

    public string Description { get; set; }

    public IFormFile Photo { get; set; }
}
