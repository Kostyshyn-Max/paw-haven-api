namespace PawHavenApp.BusinessLogic.Services;

using Microsoft.AspNetCore.Http;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;
using System.Diagnostics.CodeAnalysis;

public class PetPhotoService : IPetPhotoService
{
    private readonly IPetPhotoRepository petPhotoRepository;

    private readonly IS3StorageService s3StorageService;

    public PetPhotoService(ApplicationDbContext context, IS3StorageService s3StorageService)
    {
        this.petPhotoRepository = new PetPhotoRepository(context);
        this.s3StorageService = s3StorageService;
    }

    public async Task AddCardPhotosAsync(List<IFormFile> photos, int petCardId)
    {
        for (int i = 0; i < photos.Count; i++)
        {
            string? url = await this.s3StorageService.UploadFile(photos[i]);
            await this.petPhotoRepository.CreateAsync(new PetPhoto
            {
                PetCardId = petCardId,
                PetPhotoLink = url,
            });
        }
    }

    public async Task<string?> AddStoryPhotoAsync(IFormFile photo)
    {
        return await this.s3StorageService.UploadFile(photo);
    }
}