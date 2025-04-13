using PawHavenApp.DataAccess.EF;

namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class OrganisationCategoryRepository : AbstractRepository, IOrganisationCategoryRepository
{
    private readonly DbSet<OrganisationCategory> dbSet;

    public OrganisationCategoryRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<OrganisationCategory>();
    }

    public Task<int> CreateAsync(OrganisationCategory entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrganisationCategory>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public Task<IEnumerable<OrganisationCategory>> GetAllAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrganisationCategory>> GetAllAsync(Expression<Func<OrganisationCategory, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<OrganisationCategory?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrganisationCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(OrganisationCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}