using FluentMigrator;
using Gft.Migratior.Migrations.MigrationsConfig;
using System;

namespace Gft.Migratior.Migrations
{
    [Migration(080220210128)]
    public class FoodMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("food");
        }

        public override void Up()
        {
            Create.Table("food")
            .CreateBase(false)
            .WithColumn("name")
            .AsString(255)
            .NotNullable()
            
            .WithColumn("type")
            .AsString(10)
            .NotNullable()
            
            .WithColumn("time_meal")
            .AsString(20)
            .NotNullable();
        }
    }
}
