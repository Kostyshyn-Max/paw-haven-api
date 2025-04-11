namespace PawHavenApp.BusinessLogic.Configurations;

public class AwsS3Settings
{
    public string AccessKey { get; set; }

    public string SecretKey { get; set; }

    public string Region { get; set; }

    public string BucketName { get; set; }
}