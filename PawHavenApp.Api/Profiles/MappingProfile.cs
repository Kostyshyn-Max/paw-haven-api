namespace PawHavenApp.Api.Profiles;

using AutoMapper;
using PawHavenApp.Api.ViewModels;
using PawHavenApp.BusinessLogic.Models;
using PawHavenApp.DataAccess.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<UserCreateViewModel, UserCreateModel>();
        this.CreateMap<UserLoginViewModel, UserLoginModel>();
        this.CreateMap<UserModel, User>();
        this.CreateMap<User, UserModel>();
        this.CreateMap<UserCreateModel, User>();
        this.CreateMap<OrganisationCreateViewModel, OrganisationCreateModel>();
        this.CreateMap<OrganisationCreateModel, Organisation>();
    }
}