using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using LibHub.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using LibHub.Domain.Categories;


namespace LibHub.Services.CategoryService
{
    public class CategoryAppService : ApplicationService , ICategoryAppService
    {

        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryAppService(IRepository<Category, Guid> CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto input)
        {
            try
            {
                var category = ObjectMapper.Map<Category>(input);
      

                var result = await _categoryRepository.InsertAsync(category);
                return ObjectMapper.Map<CategoryDto>(result);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Could not create because of this reason " + ex.Message);
            }
        }

        public async Task DeleteCategory(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return ObjectMapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateCategoryAsync( CategoryDto input)
        {
            var category = ObjectMapper.Map<Category>(input);
   

            var result = await _categoryRepository.UpdateAsync(category);
            return ObjectMapper.Map<CategoryDto>(result);
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll().ToListAsync();
            return ObjectMapper.Map<List<CategoryDto>>(categories);
        }





    }
    

   
        
    
}
