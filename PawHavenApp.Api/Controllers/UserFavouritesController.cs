namespace PawHavenApp.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Repositories;
using System.Collections;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class UserFavouritesController : ControllerBase
{
    private readonly IUserFavouritesService userFavouritesService;
    private readonly IMapper mapper;

    public UserFavouritesController(IUserFavouritesService userFavouritesService, IMapper mapper)
    {
        this.mapper = mapper;
        this.userFavouritesService = userFavouritesService;
    }

    [Authorize]
    [HttpGet("get/{userId:guid}")]
    public async Task<IEnumerable<PetCardModel>> GetAllFavouritesByUser(Guid userId)
    {
        return await userFavouritesService.GetAllFavouritesByUser(userId);
    }

    [Authorize]
    [HttpPost("like/{petCardId:int}")]
    public async Task<ActionResult<int?>> AddToFavourites([FromRoute] int petCardId)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        if (await userFavouritesService.IsFavouriteExists(petCardId, userId))
        {
            return BadRequest();
        }

        await this.userFavouritesService.CreateAsync(petCardId, userId);
        return Ok();
    }

    [Authorize]
    [HttpDelete("unlike/{petCardId:int}")]
    public async Task<IActionResult> DeleteFromFavourites([FromRoute] int petCardId)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        await userFavouritesService.DeleteAsync(petCardId, userId);

        return NoContent();
    }
}
