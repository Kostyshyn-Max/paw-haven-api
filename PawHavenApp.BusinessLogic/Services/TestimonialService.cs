namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class TestimonialService : ITestimonialService
{
    private readonly ITestimonialRepository testimonialRepository;
    private readonly IMapper mapper;
    private readonly DbSet<Testimonial> dbSet;

    public TestimonialService(ApplicationDbContext context, IMapper mapper)
    {
        this.testimonialRepository = new TestimonialRepository(context);
        this.mapper = mapper;
        this.dbSet = context.Set<Testimonial>();
    }

    public async Task<int?> CreateAsync(TestimonialModel testimonial, Guid userId)
    {
        Testimonial? testimonialEntity = this.mapper.Map<Testimonial>(testimonial);
        if (testimonialEntity is null)
        {
            return null;
        }

        testimonialEntity.AuthorId = userId;
        testimonialEntity.PostedDate = DateTime.UtcNow;

        return await this.testimonialRepository.CreateAsync(testimonialEntity);
    }

    public async Task<List<TestimonialGetModel>> GetAllTestimonialsByOrganisationIdAsync(int organisationId)
    {
        var testimonials = await this.dbSet
        .Where(t => t.OrganisationId == organisationId)
        .Select(t => new TestimonialGetModel
        {
            Id = t.Id,
            AuthorName = t.User.FirstName,
            AuthorLastName = t.User.LastName,
            Message = t.Message,
            Rate = t.Rate,
        })
        .ToListAsync();

        return testimonials;
    }
}
