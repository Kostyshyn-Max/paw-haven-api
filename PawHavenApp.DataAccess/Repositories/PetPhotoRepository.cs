namespace PawHavenApp.DataAccess.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;

public class PetPhotoRepository : AbstractRepository, IPetPhotoRepository
{
    private readonly DbSet<PetPhoto> dbSet;

    public PetPhotoRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<PetPhoto>();
    }

    public async Task<int> CreateAsync(PetPhoto entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = await this.dbSet.AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<IEnumerable<PetPhoto>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<IEnumerable<PetPhoto>> GetAllAsync(int page, int pageSize)
    {
        var petPhotos = await this.dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return petPhotos;
    }

    public async Task<IEnumerable<PetPhoto>> GetAllAsync(Expression<Func<PetPhoto, bool>> predicate)
    {
        var petPhotos = await this.dbSet.Where(predicate).ToListAsync();
        return petPhotos;
    }

    public async Task<PetPhoto?> GetByIdAsync(int id)
    {
        var petPhoto = await this.dbSet.FindAsync(id);
        return petPhoto;
    }

    public async Task UpdateAsync(PetPhoto entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Update(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PetPhoto entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        this.dbSet.Remove(entity);
        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var petPhoto = await this.dbSet.FindAsync(id);
        if (petPhoto is not null)
        {
            this.dbSet.Remove(petPhoto);
            await this.context.SaveChangesAsync();
        }
    }
}