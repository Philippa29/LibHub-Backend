using Abp.Application.Services;
using LibHub.Services.Dtos;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Abp.IdentityFramework;
using Abp.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHub.Domain.Users; 
using LibHub.Authorization.Users;
using Microsoft.EntityFrameworkCore;


namespace LibHub.Services.LibrarianService
{
    public class LibrarianAppService : ApplicationService,  ILibrarianAppService 
    {
        private readonly IRepository<Librarian, Guid> _librarianRepository;
        private readonly UserManager _userManager;


        //constructor to inject the repository and userManager
        public LibrarianAppService(IRepository<Librarian , Guid> librarianRepository, UserManager userManager)
        {
            _librarianRepository = librarianRepository;
            _userManager = userManager;
        }

        public async Task<LibrarianDto> CreateLibrarianAsync(LibrarianDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            user.UserName = input.StaffID;

            ////Console.WriteLine("Email: " + user.EmailAddress);

            ObjectMapper.Map(input, user);
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password)); 

            var librarian = ObjectMapper.Map<Librarian>(input);
            librarian.User = user; 
            await _librarianRepository.InsertAsync(librarian);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<LibrarianDto>(librarian);
        }

        public async Task DeleteLibrarian(Guid id)
        {
            await _librarianRepository.DeleteAsync(id);
        }

        public async Task<LibrarianDto> GetLibrarianAsync(Guid id)
        {
            //linq query to get the librarian by id
            var librarian = await _librarianRepository.GetAllIncluding(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
            if(librarian == null)
            {
                throw new UserFriendlyException("lirarian not found!");
            }

    
            return ObjectMapper.Map<LibrarianDto>(librarian);
        }

        public async Task<LibrarianDto> UpdateLibrarianAsync(LibrarianDto input)
        {
            var librarian = await _librarianRepository.GetAsync(input.Id);
            var update = await _librarianRepository.UpdateAsync(ObjectMapper.Map(input, librarian)); 
            
            return ObjectMapper.Map<LibrarianDto>(update);
        }

    
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
