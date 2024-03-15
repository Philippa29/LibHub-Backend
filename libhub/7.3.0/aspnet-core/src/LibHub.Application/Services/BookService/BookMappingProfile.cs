using AutoMapper;
using LibHub.Domain.Books;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.BookService
{
    public class  BookMappingProfile : Profile 
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();


        }
        
    }
}
