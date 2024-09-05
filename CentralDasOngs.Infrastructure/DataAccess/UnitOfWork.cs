using CentralDasOngs.Domain.Repositories;

namespace CentralDasOngs.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly CentralDasOngsDbContext _dbContext;

    public UnitOfWork(CentralDasOngsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}