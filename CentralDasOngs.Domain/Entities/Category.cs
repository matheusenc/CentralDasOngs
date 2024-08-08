namespace CentralDasOngs.Domain.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<ContributorCategoryInterest> ContributorCategoryInterests { get; set; } = [];
    public IList<Project> Projects { get; set; } = [];
}