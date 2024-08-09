namespace CentralDasOngs.Domain.Repositories.ContributorProjectAssignment;

public interface IReadOnlyContributorProjectAssignmentRepository
{
    Task<List<Entities.ContributorProjectAssignment>> GetAllByContributor(long contributorId);
    Task<List<Entities.ContributorProjectAssignment>> GetAllByProject(long projectId);
}