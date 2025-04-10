namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class OrganisationRepository : AbstractRepository, IOrganisationRepository
{
    private readonly DbSet<Organisation> dbSet;

    public OrganisationRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<Organisation>();
    }

    public async Task<int> CreateAsync(Organisation entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<Organisation>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<Organisation>> GetAllAsync(int page, int pageSize)
    {
        var organisations = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return organisations;
    }

    public async Task<IEnumerable<Organisation>> GetAllAsync(Expression<Func<Organisation, bool>> predicate)
    {
        var organisations = await this.dbSet.Where(predicate).ToListAsync();
        return organisations;
    }

    public async Task<Organisation?> GetByIdAsync(int id)
    {
        var organisation = await this.dbSet.FindAsync(id);
        return organisation;
    }

    public async Task UpdateAsync(Organisation entity)
    {
        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Organisation entity)
    {
        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var organisation = await this.dbSet.FindAsync(id);
        if (organisation is not null)
        {
            this.dbSet.Remove(organisation);
            await this.context.SaveChangesAsync();
        }
    }
}