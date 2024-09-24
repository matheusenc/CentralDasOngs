using FluentMigrator;
using System.Data;

namespace CentralDasOngs.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.INITIAL_TABLES, "Initial database tables")]
public class Version0000001 : VersionBase
{
    private const string ADDRESS_TABLE_NAME = "Addresses";
    private const string CATTEGORY_TABLE_NAME = "Categories";
    private const string CONTRIBUTOR_TABLE_NAME = "Contributors";
    private const string ONG_TABLE_NAME = "Ongs";
    private const string PROJECT_TABLE_NAME = "Projects";
    private const string CONTRIBUTORCATEGORYINTEREST_TABLE_NAME = "ContributorCategoryInterests";
    private const string CONTRIBUTORPROJECTASSIGNMENT_TABLE_NAME = "ContributorProjectAssignments";
    
    public override void Up()
    {
        //Metodo diferente pois a classe Category não tem herança com a EntityBase
        Create.Table(CATTEGORY_TABLE_NAME)
            .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
            .WithColumn("Name").AsString().NotNullable();

        CreateTable(ADDRESS_TABLE_NAME)
            .WithColumn("Country").AsString(56).NotNullable()
            .WithColumn("PostalCode").AsString(20).NotNullable()
            .WithColumn("State").AsString(50).NotNullable()
            .WithColumn("City").AsString(100).NotNullable()
            .WithColumn("Neighborhood").AsString(100).Nullable()
            .WithColumn("Street").AsString(150).Nullable()
            .WithColumn("Number").AsInt32().Nullable()
            .WithColumn("Complement").AsString(100).Nullable();
        
        CreateUserTable(ONG_TABLE_NAME, userType: "Ong")
            .WithColumn("Cnpj").AsString(18).NotNullable();
        
        CreateUserTable(CONTRIBUTOR_TABLE_NAME, userType: "Contributor")
            .WithColumn("Cpf").AsString(14).NotNullable();
        
        CreateTable(PROJECT_TABLE_NAME)
            .WithColumn("Type").AsInt32().NotNullable()
            .WithColumn("ContributorCount").AsInt32().NotNullable()
            .WithColumn("Description").AsString(1000).NotNullable()
            .WithColumn("ImageIdentifier").AsString(255).NotNullable()
            .WithColumn("CategoryId").AsInt64().NotNullable().ForeignKey("FK_Project_Category_Id", "Categories", "Id")
            .WithColumn("OngId").AsInt64().NotNullable().ForeignKey("FK_Project_Ong_Id", "Ongs", "Id")
            .OnDelete(Rule.Cascade);
        
        CreateTable(CONTRIBUTORCATEGORYINTEREST_TABLE_NAME)
            .WithColumn("ContributorId").AsInt64().NotNullable().ForeignKey("FK_ContributorCategoryInterest_Contributor_Id", "Contributors", "Id")
            .WithColumn("CategoryId").AsInt64().NotNullable().ForeignKey("FK_ContributorCategoryInterest_Category_Id", "Categories", "Id")
            .OnDelete(Rule.Cascade); ;
        
        CreateTable(CONTRIBUTORPROJECTASSIGNMENT_TABLE_NAME)
            .WithColumn("ContributorId").AsInt64().NotNullable().ForeignKey("FK_ContributorProjectAssignment_Contributor_Id", "Contributors", "Id")
            .WithColumn("ProjectId").AsInt64().NotNullable().ForeignKey("FK_ContributorProjectAssignment_Category_Id", "Projects", "Id")
            .OnDelete(Rule.Cascade);
    }
}