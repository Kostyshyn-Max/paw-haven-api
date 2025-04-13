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
        this.CreateMap<Organisation, OrganisationCreateModel>();
        this.CreateMap<TestimonialModel, Testimonial>();
        this.CreateMap<Testimonial, TestimonialModel>();
        this.CreateMap<TestimonialCreateViewModel, TestimonialModel>();
        this.CreateMap<UserModel, UserProfileViewModel>();
        this.CreateMap<Organisation, OrganisationModel>();
        this.CreateMap<PetCardModel, PetCard>();
        this.CreateMap<PetPhoto, PetPhotoModel>();
        this.CreateMap<PetType, PetTypeModel>();
        this.CreateMap<HealthStatus, HealthStatusModel>();
        this.CreateMap<PetCard, PetCardModel>();
        this.CreateMap<PetCardModel, PetCardViewModel>()
            .ForMember(o => o.PetPhoto, options => options.Ignore());
        this.CreateMap<PetPhotoModel, PetPhotoViewModel>();
        this.CreateMap<OrganisationCategory, OrganisationCategoryModel>();
        this.CreateMap<PetCardCreateModel, PetCardModel>()
            .ForMember(p => p.Photos, options => options.Ignore());
        this.CreateMap<PetCardModel, PetCardDetailsViewModel>();
        this.CreateMap<UserUpdateViewModel, UserUpdateModel>();
        this.CreateMap<User, OrganisationUserModel>();
        this.CreateMap<PetStoryCreateModel, PetStoryModel>();
        this.CreateMap<PetStoryModel, PetStory>();
        this.CreateMap<PetStory, PetStoryModel>();
    }
}