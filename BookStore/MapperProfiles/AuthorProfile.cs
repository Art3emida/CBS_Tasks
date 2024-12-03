namespace BookStore.MapperProfiles;

using AutoMapper;
using BookStore.Dto;
using BookStore.Models;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<CreateAuthorRequestDto, Author>();
        CreateMap<EditAuthorRequestDto, Author>();
    }
}
