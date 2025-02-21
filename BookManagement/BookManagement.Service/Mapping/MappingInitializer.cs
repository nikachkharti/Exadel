using AutoMapper;
using BookManagement.Models.Dtos;
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
            });

            return configuration.CreateMapper();
        }
    }
}
