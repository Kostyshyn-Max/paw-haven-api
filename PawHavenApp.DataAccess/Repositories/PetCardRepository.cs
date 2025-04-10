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
        dbSet = context.Set<PetCard>();
    }

    public async Task<int> CreateAsync(PetCard entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var entry = await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();

        return entry.Entity.Id;
    }

    public async Task<IEnumerable<PetCard>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<IEnumerable<PetCard>> GetAllAsync(int page, int pageSize)
    {
        var petCards = await dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return petCards;
    }

    public async Task<IEnumerable<PetCard>> GetAllAsync(Expression<Func<PetCard, bool>> predicate)
    {
        var petCards = await dbSet.Where(predicate).ToListAsync();
        return petCards;
    }

    public async Task<PetCard?> GetByIdAsync(int id)
    {
        var petCard = await dbSet.FindAsync(id);
        return petCard;
    }

    public async Task UpdateAsync(PetCard entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PetCard entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var petCard = await dbSet.FindAsync(id);
        if (petCard is not null)
        {
            dbSet.Remove(petCard);
            await context.SaveChangesAsync();
        }
    }
}