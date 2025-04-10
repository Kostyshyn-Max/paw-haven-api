namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IMessageRepository : ICrudRepository<Message, int>
{
}