using Amazon.S3.Model;
using Microsoft.Extensions.Logging;
using PawHavenApp.BusinessLogic.Configurations;

namespace PawHavenApp.BusinessLogic.Services;

using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PawHavenApp.BusinessLogic.Interfaces;

public class S3StorageService : IS3StorageService
{
    private readonly IAmazonS3 s3Client;
    private readonly ILogger<S3StorageService> logger;
    private readonly string bucketName;

    public S3StorageService(IAmazonS3 s3Client, ILogger<S3StorageService> logger, IOptions<AwsS3Settings> options)
    {
        this.s3Client = s3Client;
        this.logger = logger;
        this.bucketName = options.Value.BucketName;
    }

    public async Task<string?> UploadFile(IFormFile file)
    {
        using var stream = file.OpenReadStream();

        var key = Guid.NewGuid() + Path.GetExtension(file.FileName);

        var request = new PutObjectRequest()
        {
            BucketName = this.bucketName,
            Key = key,
            InputStream = stream,
            ContentType = file.ContentType,
        };

        await this.s3Client.PutObjectAsync(request);
        return $"https://{this.bucketName}.s3.amazonaws.com/{key}";
    }

    public async Task<bool> DeleteFile(string path)
    {
        try
        {
            var uri = new Uri(path);
            var key = uri.AbsolutePath.TrimStart('/');

            var request = new DeleteObjectRequest()
            {
                BucketName = this.bucketName,
                Key = key,
            };

            var response = await this.s3Client.DeleteObjectAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.NoContent;
        }
        catch (Exception e)
        {
            this.logger.LogError(e.Message);
            return false;
        }
    }
}