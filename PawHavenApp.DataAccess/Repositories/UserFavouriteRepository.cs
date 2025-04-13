namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class UserFavouriteRepository : AbstractRepository, IUserFavouriteRepository
{
    private readonly DbSet<UserFavourite> dbSet;

    public UserFavouriteRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<UserFavourite>();
    }

    public async Task<int> CreateAsync(UserFavourite entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<UserFavourite>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<UserFavourite>> GetAllAsync(int page, int pageSize)
    {
        var userFavourites = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return userFavourites;
    }

    public async Task<IEnumerable<UserFavourite>> GetAllAsync(Expression<Func<UserFavourite, bool>> predicate)
    {
        var userFavourites = await this.dbSet.Where(predicate)
            .Include(u => u.PetCard)
                .ThenInclude(pc => pc.Photos)
            .Include(u => u.PetCard)
                .ThenInclude(pc => pc.HealthStatus)
            .Include(u => u.PetCard)
                .ThenInclude(pc => pc.PetType)
            .Include(p => p.User)
                .ThenInclude(u => u.Organisation)
            .ToListAsync();
        return userFavourites;
    }

    public async Task<UserFavourite?> GetByIdAsync(int id)
    {
        var userFavourite = await this.dbSet.FindAsync(id);
        return userFavourite;
    }

    public async Task<UserFavourite?> GetByIdAsync(int petCardId, Guid userId)
    {
        var userFavourite = await this.dbSet.FirstOrDefaultAsync(l => l.PetCardId == petCardId && l.UserId == userId);
        return userFavourite;
    }

    public async Task UpdateAsync(UserFavourite entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(UserFavourite entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var userFavourite = await this.dbSet.FindAsync(id);
        if (userFavourite is not null)
        {
            this.dbSet.Remove(userFavourite);
            await this.context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int petCardId, Guid userId)
    {
        var userFavourite = await this.dbSet.FirstOrDefaultAsync(l => l.PetCardId == petCardId && l.UserId == userId);
        if (userFavourite is not null)
        {
            this.dbSet.Remove(userFavourite);
            await this.context.SaveChangesAsync();
        }
    }
}