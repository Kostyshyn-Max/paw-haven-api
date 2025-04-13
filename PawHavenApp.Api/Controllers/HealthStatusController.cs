namespace PawHavenApp.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;

[ApiController]
[Route("api/[controller]/")]
public class HealthStatusController : ControllerBase
{
    private readonly IHealthStatusService healthStatusService;

    public HealthStatusController(IHealthStatusService healthStatusService)
    {
        this.healthStatusService = healthStatusService;
    }

    [HttpGet("/api/health/statuses")]
    public async Task<IEnumerable<HealthStatusModel>> GetAllStatusesAsync()
    {
        return await this.healthStatusService.GetAllAsync();
    }
}