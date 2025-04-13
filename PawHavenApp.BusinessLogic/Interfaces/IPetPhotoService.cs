namespace PawHavenApp.BusinessLogic.Interfaces;

using Microsoft.AspNetCore.Http;

public interface IPetPhotoService
{
    Task AddCardPhotosAsync(List<IFormFile> photos, int petCardId);

    Task<string?> AddStoryPhotoAsync(IFormFile photo);
}