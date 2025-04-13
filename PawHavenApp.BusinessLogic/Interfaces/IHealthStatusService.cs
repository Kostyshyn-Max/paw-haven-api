namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;

public interface IHealthStatusService
{
    Task<IEnumerable<HealthStatusModel>> GetAllAsync();
}