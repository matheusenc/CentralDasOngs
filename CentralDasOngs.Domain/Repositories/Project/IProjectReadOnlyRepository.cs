namespace CentralDasOngs.Domain.Repositories.Project;

public interface IProjectReadOnlyRepository
{
    Task<List<Entities.Project?>> GetAll();
    Task<Entities.Project?> GetById(long projectId);
}