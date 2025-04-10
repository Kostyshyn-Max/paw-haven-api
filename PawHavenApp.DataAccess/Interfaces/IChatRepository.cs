namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IChatRepository : ICrudRepository<Chat, int>
{
}