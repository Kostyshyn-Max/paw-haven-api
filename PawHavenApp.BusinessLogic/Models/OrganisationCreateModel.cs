namespace PawHavenApp.BusinessLogic.Models;

public class OrganisationCreateModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Location { get; set; }

    public string? DonationCredentials { get; set; }

    public int OrganisationCategoryId { get; set; }

    public Guid OwnerId { get; set; }
}