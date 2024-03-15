using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibHub.Domain.Books;
using LibHub.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
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

        public BookAppService(IRepository<Book,Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [HttpPost]
        [Route("CreateBook")]

        public async Task<BookDto> CreateBookAsync(BookDto input)
        {
            try
            {
                var book = ObjectMapper.Map<BookDto>(input);


                var result = ObjectMapper.Map<Book>(input); 
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

        public async Task<List<BookDto>> GetBookAsync(Guid id)
        {
            var book = await _bookRepository.GetAsync(id);
            return ObjectMapper.Map<List<BookDto>>(book);
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
