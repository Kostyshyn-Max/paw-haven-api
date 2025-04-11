using Microsoft.Extensions.Configuration;

namespace PawHavenApp.BusinessLogic.Services;

using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    private readonly IJwtService jwtService;
    private readonly IConfiguration configuration;

    public UserService(ApplicationDbContext context, IMapper mapper, IJwtService jwtService, IConfiguration configuration)
    {
        this.userRepository = new UserRepository(context);
        this.mapper = mapper;
        this.jwtService = jwtService;
        this.configuration = configuration;
    }

    public async Task<Guid?> RegisterUserAsync(UserCreateModel user)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(32);
        byte[] password = Encoding.UTF8.GetBytes(user.Password);

        string hashPassword = this.GenerateHash(password, salt);
        string saltString = Convert.ToBase64String(salt);

        User? userEntity = this.mapper.Map<UserCreateModel, User>(user);

        if (userEntity is null)
        {
            return null;
        }

        userEntity.PasswordHash = hashPassword;
        userEntity.PasswordSalt = saltString;
        userEntity.RoleId = user.IsOrganisationOwner ? (int)UserRoles.OrganisationOwner : (int)UserRoles.User;
        userEntity.RegistrationDate = DateTime.UtcNow;

        return await this.userRepository.CreateAsync(userEntity);
    }

    public async Task<UserTokenDataModel?> LoginAsync(UserLoginModel user)
    {
        var passwordSalt = await this.userRepository.GetUserSalt(user.Email);

        if (passwordSalt is null)
        {
            return null;
        }

        byte[] password = Encoding.UTF8.GetBytes(user.Password);
        string hashedPassword = this.GenerateHash(password, Convert.FromBase64String(passwordSalt));

        var userEntity = await this.userRepository.LoginAsync(user.Email, hashedPassword);
        if (userEntity is null)
        {
            return null;
        }

        string token = this.jwtService.GenerateAccessToken(this.mapper.Map<UserModel>(userEntity));
        string refreshToken = this.jwtService.GenerateRefreshToken();

        userEntity.RefreshToken = refreshToken;
        userEntity.RefreshTokenExpireDate = DateTime.UtcNow.AddDays(int.Parse(this.configuration["JWT:RefreshTokenExpirationDays"] ?? "7"));

        await this.userRepository.UpdateAsync(userEntity);

        return new UserTokenDataModel()
        {
            Token = token,
            RefreshToken = refreshToken,
        };
    }

    private string GenerateHash(byte[] password, byte[] salt)
    {
        byte[] hash = SHA256.HashData(password.Concat(salt).ToArray());
        return Convert.ToBase64String(hash);
    }
}