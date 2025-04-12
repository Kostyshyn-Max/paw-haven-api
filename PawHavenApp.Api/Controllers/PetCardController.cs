namespace PawHavenApp.Api.Controllers;

using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.Api.ViewModels;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
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
    [HttpPost("add")]
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

    [HttpGet("")]
    [HttpGet("{page:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<PetCardViewModel>> GetPetCards(int? page, int? pageSize)
    {
        List<PetCardViewModel> result;

        if (page is null && pageSize is null)
        {
            var petCards = await this.petCardService.GetAllPetCardsAsync();
            result = this.CollectPetCards(petCards);
        }
        else
        {
            var petCards = await this.petCardService.GetAllPetCardsAsync((int)page!, (int)pageSize!);
            result = this.CollectPetCards(petCards);
        }

        return result;
    }

    private List<PetCardViewModel> CollectPetCards(List<PetCardModel> petCards)
    {
        List<PetCardViewModel> result = new List<PetCardViewModel>();
        foreach (var petCard in petCards)
        {
            var petCardViewModel = this.mapper.Map<PetCardViewModel>(petCard);
            petCardViewModel.PetPhoto = this.mapper.Map<PetPhotoViewModel>(petCard.Photos.FirstOrDefault());
            result.Add(petCardViewModel);
        }

        return result;
    }
}