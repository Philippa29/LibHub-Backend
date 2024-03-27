using Abp.Application.Services;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.CategoryService
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<CategoryDto> CreateCategoryAsync(CategoryDto input);
        Task<CategoryDto> UpdateCategoryAsync(CategoryDto input);

        Task<CategoryDto> GetCategoryAsync(Guid id);

        Task<List<CategoryDto>> GetAllCategories(); 

        Task DeleteCategory(Guid id);
    }
}
