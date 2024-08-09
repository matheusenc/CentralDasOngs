namespace CentralDasOngs.Domain.Repositories.Project;

public interface IProjectUpdateOnlyRepository
{
    Task<Entities.Project?> GetById(long projectId);
    void Update(Entities.Project project);
}