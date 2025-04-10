namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class PetStoryRepository : AbstractRepository, IPetStoryRepository
{
    private readonly DbSet<PetStory> dbSet;

    public PetStoryRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<PetStory>();
    }

    public async Task<int> CreateAsync(PetStory entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<PetStory>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<PetStory>> GetAllAsync(int page, int pageSize)
    {
        var petStories = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return petStories;
    }

    public async Task<IEnumerable<PetStory>> GetAllAsync(Expression<Func<PetStory, bool>> predicate)
    {
        var petStories = await this.dbSet.Where(predicate).ToListAsync();
        return petStories;
    }

    public async Task<PetStory?> GetByIdAsync(int id)
    {
        var petStory = await this.dbSet.FindAsync(id);
        return petStory;
    }

    public async Task UpdateAsync(PetStory entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PetStory entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var petStory = await this.dbSet.FindAsync(id);

        if (petStory is not null)
        {
            this.dbSet.Remove(petStory);
            await this.context.SaveChangesAsync();
        }
    }
}