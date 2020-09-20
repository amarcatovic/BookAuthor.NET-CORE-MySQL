using AutoMapper;
using BookAuthor_MySQL.Data.Dtos;
using BookAuthor_MySQL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Mapping_Profiles
{
    public class AuthorProfiles: Profile
    {
        public AuthorProfiles()
        {
            CreateMap<Author, AuthorReadDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => 
                    src.AuthorBooks
                        .Select(ab => ab.Book)));

            CreateMap<Author, AuthorPatchDto>().ReverseMap();
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorBasicReadDto>();
        }
    }
}
