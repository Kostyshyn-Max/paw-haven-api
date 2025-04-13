namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class HealthStatusService : IHealthStatusService
{
    private readonly IHealthStatusRepository healthStatusRepository;
    private readonly IMapper mapper;

    public HealthStatusService(ApplicationDbContext context, IMapper mapper)
    {
        this.healthStatusRepository = new HealthStatusRepository(context);
        this.mapper = mapper;
    }

    public async Task<IEnumerable<HealthStatusModel>> GetAllAsync()
    {
        var healthStatuses = await this.healthStatusRepository.GetAllAsync();
        return healthStatuses.Select(h => this.mapper.Map<HealthStatusModel>(h));
    }
}