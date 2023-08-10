﻿using AutoMapper;
using BookStore.Entities;
using static BookStore.BookOperations.GetBookDetail.GetBooksQuery;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src. GenreID).ToString()));
        }
    }
}
