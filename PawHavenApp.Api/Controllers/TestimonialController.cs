﻿namespace PawHavenApp.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.BusinessLogic.Services;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Repositories;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly ITestimonialService testimonialService;
    private readonly IMapper mapper;

    public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
    {
        this.mapper = mapper;
        this.testimonialService = testimonialService;
    }

    [Authorize]
    [HttpPost]
    public async Task AddTestimonial([FromBody] TestimonialModel testimonial)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        await this.testimonialService.CreateAsync(testimonial, userId);
    }

    [HttpGet("{organisationId:int}")]
    public async Task<ActionResult<IEnumerable<TestimonialGetModel>>> GetOrganisationTestimonials([FromRoute] int organisationId)
    {
       return await testimonialService.GetAllTestimonialsByOrganisationIdAsync(organisationId);
    }
}
