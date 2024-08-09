namespace CentralDasOngs.Domain.Repositories.Category;

public interface IReadOnlyCategoryRepository
{
    Task<List<Entities.Category>> GetAll();
}