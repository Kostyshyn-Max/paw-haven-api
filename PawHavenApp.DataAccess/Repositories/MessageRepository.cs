namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class MessageRepository : AbstractRepository, IMessageRepository
{
    private readonly DbSet<Message> dbSet;

    public MessageRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<Message>();
    }

    public async Task<int> CreateAsync(Message entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<Message>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<Message>> GetAllAsync(int page, int pageSize)
    {
        var messages = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return messages;
    }

    public async Task<IEnumerable<Message>> GetAllAsync(Expression<Func<Message, bool>> predicate)
    {
        var messages = await this.dbSet.Where(predicate).ToListAsync();
        return messages;
    }

    public async Task<Message?> GetByIdAsync(int id)
    {
        var message = await this.dbSet.FindAsync(id);
        return message;
    }

    public async Task UpdateAsync(Message entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Message entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var message = await this.dbSet.FindAsync(id);
        if (message is not null)
        {
            this.dbSet.Remove(message);
            await this.context.SaveChangesAsync();
        }
    }
}