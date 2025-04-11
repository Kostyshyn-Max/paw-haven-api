namespace PawHavenApp.Api.ViewModels;

public class PetCardViewModel
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Location { get; set; }

    public PetPhotoViewModel PetPhoto { get; set; }

    public PetTypeViewModel PetType { get; set; }
}