using PawHavenApp.Api.ViewModels;

namespace PawHavenApp.Api.Controllers;

using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;

[Route("api/[controller]/")]
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
    [HttpGet("get")]
    public async Task<IEnumerable<PetCardViewModel>> GetAllFavouritesByUser()
    {
        Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        var petCardEntities = await this.userFavouritesService.GetAllFavouritesByUser(userId);

        List<PetCardViewModel> result = new List<PetCardViewModel>();
        foreach (var petCard in petCardEntities)
        {
            var petCardViewModel = this.mapper.Map<PetCardViewModel>(petCard);
            petCardViewModel.PetPhoto = this.mapper.Map<PetPhotoViewModel>(petCard.Photos.FirstOrDefault());
            petCardViewModel.OwnerId = petCard.OwnerId.ToString(); // Встановлюємо OwnerId із моделі бізнес-логіки
            result.Add(petCardViewModel);
        }

        return result;
    }

    [Authorize]
    [HttpPost("like")]
    public async Task<ActionResult<int?>> AddToFavourites([FromBody] int petCardId)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        if (await this.userFavouritesService.IsFavouriteExists(petCardId, userId))
        {
            return this.BadRequest();
        }

        await this.userFavouritesService.CreateAsync(petCardId, userId);
        return this.Ok();
    }

    [Authorize]
    [HttpDelete("unlike/{petCardId:int}")]
    public async Task<IActionResult> DeleteFromFavourites([FromRoute] int petCardId)
    {
        Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        await this.userFavouritesService.DeleteAsync(petCardId, userId);

        return this.Ok();
    }

    [HttpGet("is-card-saved/{petCardId:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<bool>> IsUserSavedCard(int petCardId)
    {
        if (!this.User.Identity?.IsAuthenticated ?? true)
        {
            return this.Ok(false);
        }

        Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        return await this.userFavouritesService.IsFavouriteExists(petCardId, userId);
    }
}
