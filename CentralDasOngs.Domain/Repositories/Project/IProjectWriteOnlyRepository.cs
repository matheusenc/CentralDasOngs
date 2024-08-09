namespace CentralDasOngs.Domain.Repositories.Project;

public interface IProjectWriteOnlyRepository
{
    Task Add(Entities.Project project);
    Task Delete(long projectId);
}