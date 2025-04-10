namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class PetTypeRepository : AbstractRepository, IPetTypeRepository
{
    private readonly DbSet<PetType> dbSet;

    public PetTypeRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<PetType>();
    }

    public async Task<int> CreateAsync(PetType entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<PetType>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<PetType>> GetAllAsync(int page, int pageSize)
    {
        var petTypes = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return petTypes;
    }

    public async Task<IEnumerable<PetType>> GetAllAsync(Expression<Func<PetType, bool>> predicate)
    {
        var petTypes = await this.dbSet.Where(predicate).ToListAsync();
        return petTypes;
    }

    public async Task<PetType?> GetByIdAsync(int id)
    {
        var petType = await this.dbSet.FindAsync(id);
        return petType;
    }

    public async Task UpdateAsync(PetType entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PetType entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var petType = await this.dbSet.FindAsync(id);
        if (petType is not null)
        {
            this.dbSet.Remove(petType);
            await this.context.SaveChangesAsync();
        }
    }
}