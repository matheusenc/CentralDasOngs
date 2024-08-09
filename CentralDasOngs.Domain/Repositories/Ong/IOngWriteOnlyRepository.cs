namespace CentralDasOngs.Domain.Repositories.Ong;

public interface IOngWriteOnlyRepository
{
    Task Add(Entities.Ong ong);
    Task Delete(long ongId);
}