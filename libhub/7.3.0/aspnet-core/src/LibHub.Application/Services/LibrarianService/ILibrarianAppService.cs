using Abp.Application.Services;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.LibrarianService
{
    public interface ILibrarianAppService : IApplicationService
    {
        Task<LibrarianDto> CreateLibrarianAsync(LibrarianDto input);
        Task<LibrarianDto> UpdateLibrarianAsync(LibrarianDto input);

        Task<LibrarianDto> GetLibrarianAsync(Guid id);

        Task DeleteLibrarian(Guid id);
    }
}
