namespace PawHavenApp.DataAccess.EF;

using PawHavenApp.DataAccess.Entities;

public static class DataSeed
{
    public static IEnumerable<OrganisationCategory> GetOgranisationCategories()
    {
        return new List<OrganisationCategory>
        {
            new OrganisationCategory { Id = (int)OrganisationCategories.VetClinic, Title = "Ветеринарна клініка" },
            new OrganisationCategory { Id = (int)OrganisationCategories.Shelter, Title = "Притулок" },
            new OrganisationCategory { Id = (int)OrganisationCategories.Nursery, Title = "Розплідник" },
        };
    }

    public static IEnumerable<HealthStatus> GetHealthStatuses()
    {
        return new List<HealthStatus>
        {
            new HealthStatus { Id = (int)HealthStatuses.Healthy, Title = "Здоровий" },
            new HealthStatus { Id = (int)HealthStatuses.Rehabilitated, Title = "Реабілітований" },
            new HealthStatus { Id = (int)HealthStatuses.NeedsTreatment, Title = "Потребує лікування" },
            new HealthStatus { Id = (int)HealthStatuses.Recovering, Title = "Відновлюється" },
            new HealthStatus { Id = (int)HealthStatuses.Critical, Title = "Критичний" },
        };
    }

    public static IEnumerable<PetType> GetPetTypes()
    {
        return new List<PetType>
        {
            new PetType { Id = (int)PetTypes.Cat, Title = "Кіт" },
            new PetType { Id = (int)PetTypes.Dog, Title = "Собака" },
            new PetType { Id = (int)PetTypes.Reptile, Title = "Рептилія" },
            new PetType { Id = (int)PetTypes.Other, Title = "Інші" },
        };
    }
}
