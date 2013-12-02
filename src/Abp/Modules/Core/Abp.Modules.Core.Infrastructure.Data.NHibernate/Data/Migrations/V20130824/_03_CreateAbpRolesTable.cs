﻿using FluentMigrator;

namespace Abp.Modules.Core.Data.Migrations.V20130824
{
    [Migration(2013082403)]
    public class _03_CreateAbpRolesTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("AbpRoles")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("AbpTenants", "Id")
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("DisplayName").AsString(100).NotNullable()
                .WithColumn("IsStatic").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsFrozen").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithAuditColumns();

            Insert.IntoTable("AbpRoles").Row(
                new
                    {
                        TenantId = "1",
                        Name = "Admin",
                        DisplayName = "Admin"
                    }
                );
        }

        //public override void Down()
        //{
        //    Delete.Table("AbpRoles");
        //}
    }
}
