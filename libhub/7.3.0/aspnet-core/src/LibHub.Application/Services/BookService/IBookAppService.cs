﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using LibHub.Services.Dtos;

namespace LibHub.Services.BookService
{
    public interface IBookAppService : IApplicationService
    {
        Task<BookDto> CreateBookAsync(BookDto input);
        Task<BookDto> UpdateBookAsync(Guid id);

        Task<List<BookDto>> GetBookAsync(Guid id);

        //Task<List<BookDto>> GetAllBooksAsync();

        Task<List<BookDto>> GetAvailableBooksAsync(); 


        

        Task DeleteBook(Guid id);

    }
}
