using Abp.Application.Services;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.StudentService
{
    public interface IStudentAppService : IApplicationService
    {
        Task<StudentDto> CreateStudentAsync(StudentDto input);
        Task<StudentDto> UpdateStudentAsync(StudentDto input);

        Task<StudentDto> GetStudentAsync(Guid id);

        Task DeleteStudent(Guid id);
    }
}
