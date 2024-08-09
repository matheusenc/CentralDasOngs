namespace CentralDasOngs.Domain.Repositories.ContributorProjectAssignment;

public interface IContributorProjectAssignmentWriteOnlyRepository
{
    Task Add(Entities.ContributorProjectAssignment contributorProjectAssignment);
    Task Delete(long contributorProjectAssignmentId);
}