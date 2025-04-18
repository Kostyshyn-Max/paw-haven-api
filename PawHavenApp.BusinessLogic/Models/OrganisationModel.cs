namespace PawHavenApp.BusinessLogic.Models;

public class OrganisationModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Guid  OwnerId { get; set; }

    public string? Location { get; set; }

    public string PhoneNumber { get; set; }

    public string? DonationCredentials { get; set; }

    public ICollection<PetCardModel>? PetCards { get; set; }
}