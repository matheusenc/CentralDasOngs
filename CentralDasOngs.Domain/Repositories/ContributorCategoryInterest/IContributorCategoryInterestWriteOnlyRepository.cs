namespace CentralDasOngs.Domain.Repositories.ContributorCategoryInterest;

public interface IContributorCategoryInterestWriteOnlyRepository
{
    Task Add(Entities.ContributorCategoryInterest contributorCategoryInterest);
    Task Delete(long contributorCategoryInterestId);
}