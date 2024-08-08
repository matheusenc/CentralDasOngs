namespace CentralDasOngs.Domain.Entities;

public class Contributor : UserBase
{
    public string Cpf { get; set; } = string.Empty;
    public IList<ContributorCategoryInterest> ContributorCategoryInterests { get; set; } = [];
    public IList<ContributorProjectAssignment> ContributorProjectAssignments { get; set; } = [];
}