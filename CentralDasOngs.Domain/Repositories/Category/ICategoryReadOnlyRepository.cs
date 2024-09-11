namespace CentralDasOngs.Domain.Repositories.Category;

public interface ICategoryReadOnlyRepository
{
    Task<List<Entities.Category>> GetAll(CancellationToken cancellationToken);
    Task<Entities.Category?> GetById(long categoryId, CancellationToken cancellationToken);
}