namespace PawHavenApp.BusinessLogic.Models;

public class PetPhotoModel
{
    public int Id { get; set; }

    public string PetPhotoLink { get; set; } = string.Empty;

    public int PetCardId { get; set; }
}