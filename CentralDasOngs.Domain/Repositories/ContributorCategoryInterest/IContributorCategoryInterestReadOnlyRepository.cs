namespace CentralDasOngs.Domain.Repositories.ContributorCategoryInterest;

public interface IReadOnlyContributorCategoryInterestRepository
{
    Task<List<Entities.ContributorCategoryInterest>> GetAllByContributor(long contributorId);
}