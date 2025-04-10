namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class TestimonialRepository : AbstractRepository, ITestimonialRepository
{
    private readonly DbSet<Testimonial> dbSet;

    public TestimonialRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<Testimonial>();
    }

    public async Task<int> CreateAsync(Testimonial entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<Testimonial>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<Testimonial>> GetAllAsync(int page, int pageSize)
    {
        var testimonials = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return testimonials;
    }

    public async Task<IEnumerable<Testimonial>> GetAllAsync(Expression<Func<Testimonial, bool>> predicate)
    {
        var testimonials = await this.dbSet.Where(predicate).ToListAsync();
        return testimonials;
    }

    public async Task<Testimonial?> GetByIdAsync(int id)
    {
        var testimonial = await this.dbSet.FindAsync(id);
        return testimonial;
    }

    public async Task UpdateAsync(Testimonial entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Testimonial entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var testimonial = await this.dbSet.FindAsync(id);
        if (testimonial is not null)
        {
            this.dbSet.Remove(testimonial);
            await this.context.SaveChangesAsync();
        }
    }
}