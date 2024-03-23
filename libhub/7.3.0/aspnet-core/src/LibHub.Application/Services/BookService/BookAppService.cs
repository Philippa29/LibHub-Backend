using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibHub.Domain.Books;
using LibHub.Domain.Categories;
using LibHub.Services.Dtos;
using LibHub.Services.StoredFilesService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.BookService
{
    public class BookAppService : ApplicationService , IBookAppService
    {

        private readonly IRepository<Book,Guid> _bookRepository;
        private readonly IStoredFileAppService _storedFileAppService;
        private readonly IRepository<Category, Guid> _categoryRepository;


        public BookAppService(IRepository<Book,Guid> bookRepository, IStoredFileAppService storedFileAppService, IRepository<Category, Guid> categoryRepository)
        {
            _bookRepository = bookRepository;
            _storedFileAppService = storedFileAppService;
            _categoryRepository = categoryRepository;
        }


        [HttpPost]
        [Route("CreateBook")]
        [Consumes("multipart/form-data")]

        public async Task<BookDto> CreateBookAsync([FromForm] BookDto input)
        {
            try
            {
                var storedFile = await _storedFileAppService.CreateStoredFile(new StoredFileDto { File = input.File });
                //var category = await _bookRepository.FirstOrDefaultAsync(e => e.CategoryId == input.CategoryID);
                var result = ObjectMapper.Map<Book>(input); 
                result.Image= storedFile;
                result.Category = await _categoryRepository.GetAsync(input.CategoryID);
                await _bookRepository.InsertAsync(result);
                CurrentUnitOfWork.SaveChanges();

                return ObjectMapper.Map<BookDto>(result);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Could not create because of this reason " + ex.Message);
            }
        }

        public async Task DeleteBook(Guid id)
        {
           //delete a book 
           await _bookRepository.DeleteAsync(id);
        }

        //get book by id

        public async Task<BookDto> GetBookAsync(Guid id)
        {
            var book = await _bookRepository.GetAllIncluding(x => x.Category , b => b.Image)
                .FirstOrDefaultAsync(e => e.Id == id);
            return ObjectMapper.Map<BookDto>(book);
        }

        //get book where the satus is available

        public async Task<List<BookDto>> GetAvailableBooksAsync()
        {
            var book = await _bookRepository.GetAllListAsync(e => e.BookStatus == Domain.ENums.BookStatus.Available);
            return ObjectMapper.Map<List<BookDto>>(book);
        }






        //get book by isbn number

        public async Task<List<BookDto>> GetBookByISBNAsync(string isbn)
        {
            var book = await _bookRepository.GetAllListAsync(e => e.ISBN == isbn);
            return ObjectMapper.Map<List<BookDto>>(book);
        }



        public async Task<BookDto> UpdateBookAsync(Guid id )
        {
            var book = await _bookRepository.GetAsync(id);
            var update = await _bookRepository.UpdateAsync(book);
            return ObjectMapper.Map<BookDto>(update);

        }
    }
}
