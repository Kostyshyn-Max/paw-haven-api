namespace PawHavenApp.BusinessLogic.Interfaces;

using Microsoft.AspNetCore.Http;

public interface IS3StorageService
{
    Task<string?> UploadFile(IFormFile file);

    Task<bool> DeleteFile(string path);
}