using Amazon.S3.Model;
using PawHavenApp.BusinessLogic.Configurations;

namespace PawHavenApp.BusinessLogic.Services;

using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PawHavenApp.BusinessLogic.Interfaces;

public class S3StorageService : IS3StorageService
{
    private readonly IAmazonS3 s3Client;

    private readonly string bucketName;

    public S3StorageService(IAmazonS3 s3Client, IOptions<AwsS3Settings> options)
    {
        this.s3Client = s3Client;
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
}