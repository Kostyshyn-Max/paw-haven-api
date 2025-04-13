namespace PawHavenApp.BusinessLogic.Models;

public class OrganisationUserModel
{

        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsOrganisationOwner { get; set; }
        
        public ICollection<PetCardModel> PetCards { get; set; } = new List<PetCardModel>();

}