using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System.Data;

namespace CentralDasOngs.Infrastructure.Migrations.Versions;

public abstract class VersionBase : ForwardOnlyMigration
{
    protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string tableName)
    {
        return Create.Table(tableName)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CreatedOn").AsDateTime().NotNullable()
            .WithColumn("Active").AsBoolean().NotNullable();
    }

    protected ICreateTableColumnOptionOrWithColumnSyntax CreateUserTable(string tableName, string userType)
    {
        return CreateTable(tableName)
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Email").AsString(254).NotNullable()
            .WithColumn("Password").AsString(200).NotNullable()
            .WithColumn("Description").AsString(1000).Nullable()
            .WithColumn("ImageIdentifier").AsString(255).Nullable()
            .WithColumn("AddressId").AsInt64().NotNullable().ForeignKey($"FK_{userType}_Address_Id", "Addresses", "Id")
            .OnDelete(Rule.Cascade);
    }
}