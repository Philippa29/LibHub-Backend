using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibHub.EntityFrameworkCore;
using LibHub.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LibHub.Web.Tests
{
    [DependsOn(
        typeof(LibHubWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LibHubWebTestModule : AbpModule
    {
        public LibHubWebTestModule(LibHubEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibHubWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LibHubWebMvcModule).Assembly);
        }
    }
}