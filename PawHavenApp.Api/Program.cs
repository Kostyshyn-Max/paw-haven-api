using System.Text;
using Amazon;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PawHavenApp.Api.Profiles;
using PawHavenApp.BusinessLogic.Configurations;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Services;
using PawHavenApp.DataAccess.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PawHaven API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and your JWT token.",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme,
                },
            },
            Array.Empty<string>()
        },
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        };
    });

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<AwsS3Settings>(builder.Configuration.GetSection("AWS"));

builder.Services.AddSingleton<IAmazonS3>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var settings = config.GetSection("AWS").Get<AwsS3Settings>();

    var awsConfig = new AmazonS3Config()
    {
        RegionEndpoint = RegionEndpoint.GetBySystemName(settings!.Region),
    };

    return new AmazonS3Client(settings.AccessKey, settings.SecretKey, awsConfig);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrganisationService, OrganisationService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IS3StorageService, S3StorageService>();
builder.Services.AddScoped<IPetCardService, PetCardService>();
builder.Services.AddScoped<IPetPhotoService, PetPhotoService>();
builder.Services.AddScoped<IUserFavouritesService, UserFavouriteService>();
builder.Services.AddScoped<IOrganisationCategoryService, OrganisationCategoryService>();
builder.Services.AddScoped<IPetTypeService, PetTypeService>();

builder.Services.AddSingleton<IJwtService, JwtService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
        policyBuilder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();