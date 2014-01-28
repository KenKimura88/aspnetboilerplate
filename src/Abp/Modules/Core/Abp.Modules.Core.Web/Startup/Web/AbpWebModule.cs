﻿using System.Reflection;
using Abp.Dependency;
using Abp.Modules;

namespace Abp.Startup.Web
{
    /// <summary>
    /// This module is used to use ABP in ASP.NET web applications.
    /// </summary>
    [AbpModule("Abp.Modules.Core.Web", Dependencies = new[] { "Abp.Web" })]
    public class AbpCoreWebModule : AbpModule
    {
        public override void Initialize(IAbpInitializationContext initializationContext)
        { 
            base.Initialize(initializationContext);
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
