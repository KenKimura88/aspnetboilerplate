﻿using System.Data.Entity;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFramework.Repositories;
using Abp.Tests;
using Shouldly;
using Xunit;

namespace Abp.EntityFramework.Tests.Repositories
{
    public class EntityFrameworkGenericRepositoryRegistrar_Tests : TestBaseWithLocalIocManager
    {
        [Fact]
        public void Should_Resolve_Generic_Repositories()
        {
            LocalIocManager.Register<ICurrentUnitOfWorkProvider, ThreadStaticCurrentUnitOfWorkProvider>();
            LocalIocManager.Register<IUowManager, UowManager>();

            EntityFrameworkGenericRepositoryRegistrar.RegisterForDbContext(typeof(MyDbContext), LocalIocManager);

            var entity1Repository = LocalIocManager.Resolve<IRepository<MyEntity1>>();
            entity1Repository.ShouldNotBe(null);

            var entity1RepositoryWithPk = LocalIocManager.Resolve<IRepository<MyEntity1, int>>();
            entity1RepositoryWithPk.ShouldNotBe(null);

            var entity2Repository = LocalIocManager.Resolve<IRepository<MyEntity2, long>>();
            entity2Repository.ShouldNotBe(null);
        }

        public class MyDbContext : MyBaseDbContext
        {
            public DbSet<MyEntity2> MyEntities2 { get; set; }
        }

        public abstract class MyBaseDbContext : AbpDbContext
        {
            public IDbSet<MyEntity1> MyEntities1 { get; set; }            
        }

        public class MyEntity1 : Entity
        {

        }

        public class MyEntity2 : Entity<long>
        {

        }
    }
}
