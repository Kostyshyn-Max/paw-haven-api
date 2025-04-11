namespace PawHavenApp.DataAccess.EF;

using PawHavenApp.DataAccess.Entities;

public static class DataSeed
{
    public static IEnumerable<OrganisationCategory> GetOrganisationCategories()
    {
        List<OrganisationCategory> organisationCategories = new List<OrganisationCategory>();

        string[] titles = new[] { "Притулок для тварин", "Ветеринарна клініка", "Зоозахисна організація", "Благодійний фонд", "Волонтерська група" };

        for (int i = 0; i < titles.Length; i++)
        {
            organisationCategories.Add(new OrganisationCategory { Id = i + 1, Title = titles[i] });
        }

        return organisationCategories;
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

    public static IEnumerable<UserRole> GetUserRoles()
    {
        return new List<UserRole>
        {
            new UserRole { Id = (int)UserRoles.Admin, Name = Enum.GetName(UserRoles.Admin)! },
            new UserRole { Id = (int)UserRoles.User, Name = Enum.GetName(UserRoles.User)! },
            new UserRole { Id = (int)UserRoles.OrganisationOwner, Name = "Organisation Owner" },
        };
    }
}
