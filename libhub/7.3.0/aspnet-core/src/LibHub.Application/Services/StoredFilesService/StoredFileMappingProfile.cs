using AutoMapper;
using LibHub.Domain.StoredFiles;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.StoredFilesService
{
    public class StoredFileMappingProfile : Profile
    {
        public StoredFileMappingProfile()
        {
            CreateMap<StoredFileDto, StoredFile>()
                .ForMember(x => x.Id, e => e.Ignore());
        }
    }
}
