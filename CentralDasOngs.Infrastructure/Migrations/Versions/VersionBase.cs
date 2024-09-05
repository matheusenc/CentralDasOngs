using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

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
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("Password").AsString().NotNullable()
            .WithColumn("Description").AsString().NotNullable()
            .WithColumn("ImageIdentifier").AsString().NotNullable()
            .WithColumn("AddressId").AsInt64().NotNullable().ForeignKey($"FK_{userType}_Address_Id", "Addresses", "Id");
    }
}