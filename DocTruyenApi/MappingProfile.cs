using AutoMapper;
using DocTruyenApi.DTOs;
using DocTruyenApi.Models;
namespace DocTruyenApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres));
            CreateMap<Book, BookDTO>();
            CreateMap<ChapterDTO, Chapter>()
                .ForMember(dest => dest.ChapterId, opt => opt.Ignore());
            CreateMap<Chapter, ChapterDTO>();
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }

    }
}
