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
using Microsoft.AspNetCore.Mvc;


namespace LibHub.Services.StudentService
{
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly UserManager _userManager;
        public StudentAppService(IRepository<Student, Guid> studentRepository, UserManager userManager)
        {
            _studentRepository = studentRepository;
            _userManager = userManager;
        }
        [HttpPost]
        
        public async Task<StudentDto> CreateStudentAsync(StudentDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            user.UserName = input.StudentID;
            user.Name = input.FirstName;
            user.Surname = input.LastName;
            user.EmailAddress = input.EmailAddress;

            ////Console.WriteLine("Email: " + user.EmailAddress);

            ObjectMapper.Map(input, user);
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            var student = ObjectMapper.Map<Student>(input);
            student.User = user;
            await _studentRepository.InsertAsync(student);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<StudentDto>(student);
        }

        public async Task DeleteStudent(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<StudentDto> GetStudentAsync(Guid id)
        {
            //linq query to get the librarian by id
            var student = await _studentRepository.GetAllIncluding(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                throw new UserFriendlyException("student not found!");
            }


            return ObjectMapper.Map<StudentDto>(student);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<StudentDto> UpdateStudentAsync(StudentDto input)
        {
            var student = await _studentRepository.GetAsync(input.Id);
            var update = await _studentRepository.UpdateAsync(ObjectMapper.Map(input, student));

            return ObjectMapper.Map<StudentDto>(update);
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }


    }

}
