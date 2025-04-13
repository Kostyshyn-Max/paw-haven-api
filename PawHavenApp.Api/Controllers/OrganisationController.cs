using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.BusinessLogic.Services;

namespace PawHavenApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganisationController : ControllerBase
{
    private readonly IOrganisationService _organisationService;

    public OrganisationController(IOrganisationService organisationService)
    {
        _organisationService = organisationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrganisationModel>>> GetAll()
    {
        try
        {
            var organisations = await _organisationService.GetAllAsync();
            return Ok(organisations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrganisationModel>> GetById(int id)
    {
        try
        {
            var organisation = await _organisationService.GetByIdAsync(id);
            if (organisation == null)
            {
                return NotFound($"Organisation with ID {id} not found");
            }

            return Ok(organisation);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> Create([FromBody] OrganisationCreateModel organisation)
    {
        try
        {
            // Get the current user ID from the token
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                return Unauthorized("User ID not found in token");
            }

            var organisationId = await _organisationService.CreateAsync(organisation, userId);
            if (organisationId == null)
            {
                return BadRequest("Failed to create organisation");
            }

            return CreatedAtAction(nameof(GetById), new { id = organisationId }, organisationId);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
} 