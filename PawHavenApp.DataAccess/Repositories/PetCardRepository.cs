namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class PetCardRepository : AbstractRepository, IPetCardRepository
{
    private readonly DbSet<PetCard> dbSet;

    public PetCardRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<PetCard>();
    }

    public async Task<int> CreateAsync(PetCard entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();

        return entry.Entity.Id;
    }

    public async Task<IEnumerable<PetCard>> GetAllAsync()
    {
        return await this.dbSet
                    .Include(p => p.Photos)
                    .Include(p => p.HealthStatus)
                    .Include(p => p.PetType)
                    .ToListAsync();
    }

    public async Task<IEnumerable<PetCard>> GetAllAsync(int page, int pageSize)
    {
        var petCards = await this.dbSet.Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .Include(p => p.Photos)
                                        .Include(p => p.HealthStatus)
                                        .Include(p => p.PetType)
                                        .ToListAsync();
        return petCards;
    }

    public async Task<IEnumerable<PetCard>> GetAllAsync(Expression<Func<PetCard, bool>> predicate)
    {
        var petCards = await this.dbSet
            .Where(predicate)
            .Include(p => p.Photos)
            .Include(p => p.HealthStatus)
            .Include(p => p.PetType)
            .ToListAsync();
        return petCards;
    }

    public async Task<PetCard?> GetByIdAsync(int id)
    {
        var petCard = await this.dbSet
                            .Include(p => p.User)
                                .ThenInclude(u => u.Organisation)
                            .Include(p => p.Photos)
                            .Include(p => p.HealthStatus)
                            .Include(p => p.PetType)
                            .FirstOrDefaultAsync(p => p.Id == id);
        return petCard;
    }

    public async Task UpdateAsync(PetCard entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PetCard entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var petCard = await this.dbSet.FindAsync(id);
        if (petCard is not null)
        {
            this.dbSet.Remove(petCard);
            await this.context.SaveChangesAsync();
        }
    }
}