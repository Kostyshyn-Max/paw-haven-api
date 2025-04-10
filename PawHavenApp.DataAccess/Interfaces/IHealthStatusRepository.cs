namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IHealthStatusRepository : ICrudRepository<HealthStatus, int>
{
}