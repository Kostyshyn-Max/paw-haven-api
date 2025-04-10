namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class UserRepository : AbstractRepository, IUserRepository
{
    private readonly DbSet<User> dbSet;

    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<User>();
    }

    public async Task<Guid> CreateAsync(User entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync(int page, int pageSize)
    {
        var users = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return users;
    }

    public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> predicate)
    {
        var users = await this.dbSet.Where(predicate).ToListAsync();
        return users;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await this.dbSet.FindAsync(id);
        return user;
    }

    public async Task UpdateAsync(User entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await this.dbSet.FindAsync(id);
        if (user is not null)
        {
            this.dbSet.Remove(user);
            await this.context.SaveChangesAsync();
        }
    }
}