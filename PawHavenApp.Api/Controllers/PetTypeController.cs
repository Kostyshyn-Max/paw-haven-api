namespace PawHavenApp.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;

[ApiController]
[Route("api/")]
public class PetTypeController : ControllerBase
{
    private readonly IPetTypeService petTypeService;

    public PetTypeController(IPetTypeService petTypeService)
    {
        this.petTypeService = petTypeService;
    }

    [HttpGet("pet/types")]
    public async Task<ActionResult<IEnumerable<PetTypeModel>>> GetPetTypes()
    {
        return this.Ok(await this.petTypeService.GetPetTypesAsync());
    }
}