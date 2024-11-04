using AutoMapper;
using DocTruyenApi.DTOs;
using DocTruyenApi.Models;
namespace DocTruyenApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();
            CreateMap<ChapterDTO, Chapter>();
            CreateMap<Chapter, ChapterDTO>();
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }

    }
}
