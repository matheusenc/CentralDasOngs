namespace CentralDasOngs.Domain.Repositories.Ong;

public interface IOngReadOnlyRepository
{
    Task<Entities.Ong?> GetById(long ongId);
}