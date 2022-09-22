using AutoMapper;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Data.Model;

namespace PaycoreFinalProject.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<OfferDto, Offer>().ReverseMap();

            CreateMap<UserDetailDto, User>().ReverseMap();           
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserForRegisterDto, User>().ReverseMap();
            CreateMap<UserForLoginDto, User>().ReverseMap();

        }
    }
}
