﻿using System;
using Castle.MicroKernel.Registration;
using Shouldly;
using Xunit;

namespace Abp.Tests.Dependency
{
    public class IocManager_Tests : TestBaseWithSelfIocManager
    {
        [Fact]
        public void Should_Call_Dispose_Of_Transient_Dependency_When_Object_Is_Released()
        {
            LocalIocManager.IocContainer.Register(
                Component.For<SimpleDisposableObject>().LifestyleTransient()
                );

            var obj = LocalIocManager.IocContainer.Resolve<SimpleDisposableObject>();

            LocalIocManager.IocContainer.Release(obj);

            obj.DisposeCount.ShouldBe(1);
        }

        [Fact]
        public void Should_Call_Dispose_Of_Transient_Dependency_When_IocManager_Is_Disposed()
        {
            LocalIocManager.IocContainer.Register(
                Component.For<SimpleDisposableObject>().LifestyleTransient()
                );

            var obj = LocalIocManager.IocContainer.Resolve<SimpleDisposableObject>();

            LocalIocManager.Dispose();

            obj.DisposeCount.ShouldBe(1);
        }
    }

    public class SimpleDisposableObject : IDisposable
    {
        public int DisposeCount { get; set; }

        public void Dispose()
        {
            DisposeCount++;
        }
    }
}
