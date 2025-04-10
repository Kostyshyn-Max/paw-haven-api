using PawHavenApp.DataAccess.EF;

namespace PawHavenApp.DataAccess.Repositories;

public abstract class AbstractRepository
{
    protected readonly ApplicationDbContext context;

    protected AbstractRepository(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.context = context;
    }
}