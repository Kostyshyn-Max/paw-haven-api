namespace PawHavenApp.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using PawHavenApp.Api.ViewModels;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

[ApiController]
[Route("api/[controller]/")]
public class OrganisationCategoryController : ControllerBase
{
    private readonly IOrganisationCategoryService organisationCategoryService;

    public OrganisationCategoryController(IOrganisationCategoryService organisationCategoryService)
    {
        this.organisationCategoryService = organisationCategoryService;
    }

    [HttpGet("/organisation/categories")]
    public async Task<ActionResult<IEnumerable<OrganisationCategoryModel>>> GetAll()
    {
        return this.Ok(await this.organisationCategoryService.GetAllCategoriesAsync());
    }
}