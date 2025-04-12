namespace PawHavenApp.Api.ViewModels;

using PawHavenApp.BusinessLogic.Models;

public class PetCardViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Location { get; set; }

    public PetPhotoViewModel PetPhoto { get; set; }

    public PetTypeModel PetType { get; set; }
}