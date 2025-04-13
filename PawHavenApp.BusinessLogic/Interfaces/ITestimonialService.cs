namespace PawHavenApp.BusinessLogic.Interfaces;

using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public interface ITestimonialService
{
    Task<int?> CreateAsync(TestimonialModel testimonial, Guid userId);

    Task<List<TestimonialModel>> GetAllTestimonialsByOrganisationIdAsync(int organisationId);
}
