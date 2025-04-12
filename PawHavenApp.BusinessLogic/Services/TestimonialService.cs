namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
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

    public TestimonialService(ApplicationDbContext context, IMapper mapper)
    {
        this.testimonialRepository = new TestimonialRepository(context);
        this.mapper = mapper;
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

    public async Task<List<TestimonialModel>> GetAllTestimonialsByOrganisationIdAsync(int organisationId)
    {
        var testimonials = await testimonialRepository.GetAllAsync(t => t.OrganisationId == organisationId);

        var result = mapper.Map<List<TestimonialModel>>(testimonials);

        return result;
    }
}
