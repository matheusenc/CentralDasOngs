namespace CentralDasOngs.Domain.Repositories.Contributor;

public interface IReadOnlyContributorRepository
{
    Task<Entities.Contributor?> GetById(long contributorId);
}