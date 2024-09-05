namespace CentralDasOngs.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}