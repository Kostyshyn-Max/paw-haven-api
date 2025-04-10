namespace PawHavenApp.DataAccess.Interfaces;

using PawHavenApp.DataAccess.Entities;

public interface IPetStoryRepository : ICrudRepository<PetStory, int>
{
}