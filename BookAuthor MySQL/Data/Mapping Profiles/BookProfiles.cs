using AutoMapper;
using BookAuthor_MySQL.Data.Dtos;
using BookAuthor_MySQL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Mapping_Profiles
{
    public class BookProfiles : Profile
    {
        public BookProfiles()
        {
            CreateMap<Book, BookReadDto>()
                .ForMember(dest => dest.Authors, opt =>
                    opt.MapFrom(src => src.BookAuthors
                        .Select(ba => ba.Author)));

            CreateMap<Book, BookPatchDto>().ReverseMap();
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookBasicReadDto>();
        }
    }
}
