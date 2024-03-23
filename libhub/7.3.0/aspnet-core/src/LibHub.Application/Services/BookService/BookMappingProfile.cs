using AutoMapper;
using LibHub.Domain.Books;
using LibHub.Domain.StoredFiles;
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
            CreateMap<Book, BookDto>()
           //     .ForMember(x => x.ImageId, e => e.MapFrom(x => x.Image != null ? x.Image.Id : (Guid?)null))
                .ForMember(x => x.CategoryID, e => e.MapFrom(x => x.Category != null ? x.Category.Id : (Guid?)null))
                .ForMember(x => x.File, e => e.Ignore());

            CreateMap<BookDto, Book>()
                .ForMember(x => x.Id, e => e.Ignore());

            //CreateMap<Get_BookDto, Book>()
            //    .ForMember(x => x.Image, e => e.MapFrom(x => x. != null ? x.Image.Id : (Guid?)null))
            //    .ForMember(x => x.CategoryID, e => e.MapFrom(x => x.Category != null ? x.Category.Id : (Guid?)null)); 


            //CreateMap<StoredFile, StoredFileDto>();
            //CreateMap<StoredFileDto, StoredFile>();
        }
        
    }
}
