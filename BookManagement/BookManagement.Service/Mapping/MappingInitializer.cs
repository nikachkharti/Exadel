using AutoMapper;
using BookManagement.Models.Dtos.Book;
using BookManagement.Models.Dtos.Identity;
using BookManagement.Models.Entities;

namespace BookManagement.Service.Mapping
{
    public static class MappingInitializer
    {
        public static IMapper Initialize()
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<Book, BookForGettingDto>();
                config.CreateMap<BookForCreatingDto, Book>();
                config.CreateMap<BookForUpdatingDto, Book>();


                config.CreateMap<UserDto, ApplicationUser>().ReverseMap();
                config.CreateMap<RegistrationRequestDto, ApplicationUser>()
                .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedUserName, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedEmail, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.PhoneNumber, options => options.MapFrom(source => source.PhoneNumber));
            });

            return configuration.CreateMapper();
        }
    }
}
