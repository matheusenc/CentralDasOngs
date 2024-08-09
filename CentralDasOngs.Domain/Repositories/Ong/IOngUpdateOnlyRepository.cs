namespace CentralDasOngs.Domain.Repositories.Ong;

public interface IUpdateOnlyRepository
{
    Task<Entities.Ong?> GetById(long ongId);
    void Update(Entities.Ong ong);
}