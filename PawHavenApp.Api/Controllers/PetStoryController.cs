namespace PawHavenApp.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.BusinessLogic.Interfaces;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class PetStoryController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IPetStoryService petStoryService;
    private readonly IPetPhotoService petPhotoService;

    public PetStoryController(IPetStoryService petStorySrvice, IPetPhotoService petPhotoService, IMapper mapper)
    {
        this.mapper = mapper;
        this.petStoryService = petStorySrvice;
        this.petPhotoService = petPhotoService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<bool>> AddPetStory([FromForm] PetStoryCreateModel petStory)
    {
        var petStoryModel = this.mapper.Map<PetStoryModel>(petStory);
        petStoryModel.AuthorId = Guid.Parse(this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        petStoryModel.Link = await this.petPhotoService.AddStoryPhotoAsync(petStory.Photo);
        int? petStoryId = await this.petStoryService.CreatePetStoryAsync(petStoryModel);
        if (petStoryId is null)
        {
            return this.BadRequest(false);
        }

        return this.Ok(true);
    }

    [HttpGet("")]
    [HttpGet("{page:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<PetStoryModel>> GetAllStories(int? page, int? pageSize)
    {
        List<PetStoryModel> result;

        if (page is null && pageSize is null)
        {
            result = await this.petStoryService.GetAllPetStoriesAsync();
        }
        else
        {
            result = await this.petStoryService.GetAllPetStoriesAsync((int)page!, (int)pageSize!);
        }

        return result;
    }
}
