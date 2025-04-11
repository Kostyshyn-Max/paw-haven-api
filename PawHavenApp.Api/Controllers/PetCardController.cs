using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using PawHavenApp.BusinessLogic.Models;

namespace PawHavenApp.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.Api.ViewModels;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.DataAccess.Entities;

[ApiController]
[Route("/api/[controller]/")]
public class PetCardController : ControllerBase
{
    private readonly IPetCardService petCardService;

    private readonly IPetPhotoService petPhotoService;

    private readonly IMapper mapper;

    public PetCardController(IPetCardService petCardService, IMapper mapper, IPetPhotoService petPhotoService)
    {
        this.petCardService = petCardService;
        this.mapper = mapper;
        this.petPhotoService = petPhotoService;
    }

    [Authorize]
    [HttpPost("/add")]
    public async Task<ActionResult> AddPetCard([FromForm] PetCardCreateViewModel petCard)
    {
        var petCardModel = this.mapper.Map<PetCardModel>(petCard);
        petCardModel.OwnerId = Guid.Parse(this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

        int? petCardId = await this.petCardService.CreatePetCardAsync(petCardModel);
        if (petCardId is null)
        {
            return this.BadRequest();
        }

        await this.petPhotoService.AddCardPhotosAsync(petCard.Photos.ToList(), (int)petCardId);
        return this.Ok();
    }

    [HttpGet("/{page:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<PetCardModel>> GetPetCards(int? page, int? pageSize)
    {
        List<PetCardModel> petCards;

        if (page is null && pageSize is null)
        {
            petCards = await this.petCardService.GetAllPetCardsAsync();
        }
        else
        {
            petCards = await this.petCardService.GetAllPetCardsAsync((int)page!, (int)pageSize!);
        }

        return petCards;
    }
}