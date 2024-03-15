using AutoMapper;
using LibHub.Authorization.Users;
using LibHub.Domain.Users;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.LibrarianService
{
    public class LibrarianMappingProfile : Profile
    {
        public LibrarianMappingProfile()
        {
            CreateMap<Librarian, LibrarianDto>();
            CreateMap<LibrarianDto, Librarian>();
            CreateMap<LibrarianDto, User>()
                .ForMember(e => e.Id, d => d.Ignore()); //ignores keys 

        }
    }
}
