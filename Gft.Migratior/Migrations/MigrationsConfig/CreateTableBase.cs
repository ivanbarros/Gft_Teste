using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Gft.Migratior.Migrations.MigrationsConfig
{
    public static class CreateTableBase
    {
        public static ICreateTableWithColumnSyntax CreateBase(this ICreateTableWithColumnSyntax create, bool userFK = true)
        {
            create
                .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey()
                .WithColumn("Active")
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(true)
                .WithColumn("CreateDate")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefaultValue(SystemMethods.CurrentDateTime);

            if (userFK)
                create
                    .WithColumn("IdUsuario")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey("Usuario", "Id");

            return create;
        }
        public static ICreateTableWithColumnSyntax CreateBaseNoActive(this ICreateTableWithColumnSyntax create, bool userFK = true)
        {
            create
                .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey()
                .WithColumn("CreateDate")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefaultValue(SystemMethods.CurrentDateTime);

            if (userFK)
                create
                    .WithColumn("IdUsuario")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey("Usuario", "Id");

            return create;
        }

        public static ICreateTableWithColumnSyntax CreateBaseNotNullable(this ICreateTableWithColumnSyntax create, bool userFK = true)
        {
            create
                .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey()
                .WithColumn("CreateDate")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefaultValue(SystemMethods.CurrentDateTime);

            if (userFK)
                create
                    .WithColumn("IdUsuario")
                    .AsInt32()
                    .Nullable()
                    .ForeignKey("Usuario", "Id");

            return create;
        }
    }
}
