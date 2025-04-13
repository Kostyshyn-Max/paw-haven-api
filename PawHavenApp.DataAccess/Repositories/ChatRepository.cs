namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class ChatRepository : AbstractRepository, IChatRepository
{
    private readonly DbSet<Chat> dbSet;

    public ChatRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<Chat>();
    }

    public async Task<int> CreateAsync(Chat entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<Chat>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<Chat>> GetAllAsync(int page, int pageSize)
    {
        var chats = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return chats;
    }

    public async Task<IEnumerable<Chat>> GetAllAsync(Expression<Func<Chat, bool>> predicate)
    {
        var chats = await this.dbSet.Where(predicate).ToListAsync();
        return chats;
    }

    public async Task<Chat?> GetByIdAsync(int id)
    {
        var chat = await this.dbSet.FindAsync(id);
        return chat;
    }

    public async Task UpdateAsync(Chat entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Chat entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var chat = await this.dbSet.FindAsync(id);
        if (chat is not null)
        {
            this.dbSet.Remove(chat);
            await this.context.SaveChangesAsync();
        }
    }
}