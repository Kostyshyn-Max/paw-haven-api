namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class HealthStatusRepository : AbstractRepository, IHealthStatusRepository
{
    private readonly DbSet<HealthStatus> dbSet;

    public HealthStatusRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<HealthStatus>();
    }

    public async Task<int> CreateAsync(HealthStatus entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<HealthStatus>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<HealthStatus>> GetAllAsync(int page, int pageSize)
    {
        var healthStatuses = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return healthStatuses;
    }

    public async Task<IEnumerable<HealthStatus>> GetAllAsync(Expression<Func<HealthStatus, bool>> predicate)
    {
        var healthStatuses = await this.dbSet.Where(predicate).ToListAsync();
        return healthStatuses;
    }

    public async Task<HealthStatus?> GetByIdAsync(int id)
    {
        var healthStatus = await this.dbSet.FindAsync(id);
        return healthStatus;
    }

    public async Task UpdateAsync(HealthStatus entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(HealthStatus entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var healthStatus = await this.dbSet.FindAsync(id);
        if (healthStatus is not null)
        {
            this.dbSet.Remove(healthStatus);
            await this.context.SaveChangesAsync();
        }
    }
}