namespace CentralDasOngs.Domain.Repositories.Contributor;

public interface IContributorWriteOnlyRepository
{
    Task Add(Entities.Contributor contributor);
    Task Delete(long contributorId);
}