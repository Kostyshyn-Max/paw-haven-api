using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

namespace PawHavenApp.BusinessLogic.Interfaces;

public interface ITestimonialService
{
    Task<int?> CreateAsync(TestimonialModel testimonial, Guid userId);

    Task<List<TestimonialModel>> GetAllTestimonialsByOrganisationIdAsync(int organisationId);
}
