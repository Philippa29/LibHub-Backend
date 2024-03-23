using Abp.Application.Services;
using LibHub.Domain.StoredFiles;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.StoredFilesService
{
    public interface IStoredFileAppService : IApplicationService
    {
        Task<StoredFile> CreateStoredFile(StoredFileDto input);
    }
}
