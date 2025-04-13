namespace PawHavenApp.BusinessLogic.Services;

using AutoMapper;
using PawHavenApp.BusinessLogic.Interfaces;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.EF;
using PawHavenApp.DataAccess.Entities;
using PawHavenApp.DataAccess.Interfaces;
using PawHavenApp.DataAccess.Repositories;

public class UserFavouriteService : IUserFavouritesService
{
    private readonly IUserFavouriteRepository userFavouriteRepository;
    private readonly IMapper mapper;

    public UserFavouriteService(ApplicationDbContext context, IMapper mapper)
    {
        this.userFavouriteRepository = new UserFavouriteRepository(context);
        this.mapper = mapper;
    }

    public async Task<int?> CreateAsync(int petCardId, Guid userId)
    {
        UserFavourite? userFavouriteEntity = new UserFavourite();

        userFavouriteEntity.UserId = userId;
        userFavouriteEntity.PetCardId = petCardId;

        return await this.userFavouriteRepository.CreateAsync(userFavouriteEntity);
    }

    public async Task DeleteAsync(int petCardId, Guid userId)
    {
        await userFavouriteRepository.DeleteAsync(petCardId, userId);
    }

    public async Task<List<PetCardModel>> GetAllFavouritesByUser(Guid userId)
    {
        var userFavourites = await userFavouriteRepository.GetAllAsync(t => t.UserId == userId);
        var favouriteCards = userFavourites.Select(f => f.PetCard).ToList();
        var result = mapper.Map<List<PetCardModel>>(favouriteCards);

        return result;
    }

    public async Task<bool> IsFavouriteExists(int petCardId, Guid userId)
    {
        var card = await userFavouriteRepository.GetByIdAsync(petCardId, userId);
        return !(card is null);
    }
}
