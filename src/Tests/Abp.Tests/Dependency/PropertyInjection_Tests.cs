﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Runtime.Session;
using Castle.MicroKernel.Registration;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Abp.Tests.Dependency
{
    public class PropertyInjection_Tests : TestBaseWithSelfIocManager
    {
        [Fact]
        public void Should_Inject_Session_For_ApplicationService()
        {
            var session = Substitute.For<IAbpSession>();
            session.TenantId.Returns(1);
            session.UserId.Returns(42);

            LocalIocManager.Register<MyApplicationService>();
            LocalIocManager.IocContainer.Register(
                Component.For<IAbpSession>().UsingFactoryMethod(() => session)
                );

            var myAppService = LocalIocManager.Resolve<MyApplicationService>();
            myAppService.Test();
        }

        public class MyApplicationService : ApplicationService
        {
            public void Test()
            {
                CurrentSession.ShouldNotBe(null);
                CurrentSession.TenantId.ShouldBe(1);
                CurrentSession.UserId.ShouldBe(42);
            }
        }
    }
}
