namespace CentralDasOngs.Domain.Repositories.Contributor;

public interface IContributorUpdateRepository
{
    Task<Entities.Contributor?> GetById(long contributorId);
    void Update(Entities.Contributor contributor);
}