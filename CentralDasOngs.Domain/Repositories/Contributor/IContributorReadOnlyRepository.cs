namespace CentralDasOngs.Domain.Repositories.Contributor;

public interface IContributorReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<Entities.Contributor?> GetById(long contributorId);
}