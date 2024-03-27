using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibHub.Authorization;

namespace LibHub
{
    [DependsOn(
        typeof(LibHubCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LibHubApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LibHubAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LibHubApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
