﻿using Abp.Application.Authorization;
using Abp.Application.Services;
using Abp.Authorization;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Abp.Startup.Dependency
{
    public class AbpCoreModuleApplicationDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly().BasedOn<IApplicationService>().WithService.DefaultInterfaces().WithService.Self().LifestyleTransient(),
                Component.For<IAuthorizationService>().ImplementedBy<RoleBasedAuthorizationService>().LifestyleTransient()
                );
        }
    }
}
