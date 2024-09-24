using CentralDasOngs.Domain.Entities;
using CentralDasOngs.Domain.Repositories.Contributor;
using Microsoft.EntityFrameworkCore;

namespace CentralDasOngs.Infrastructure.DataAccess.Repositories;

public class ContributorRepository : IContributorWriteOnlyRepository, IContributorUpdateRepository, IContributorReadOnlyRepository
{
    private readonly CentralDasOngsDbContext _dbContext;

    public ContributorRepository(CentralDasOngsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Contributor contributor)
    {
        await _dbContext.Contributors.AddAsync(contributor);
    }

    public Task Delete(long contributorId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        var exist = await _dbContext.Contributors.AnyAsync(c => c.Email == email && c.Active);
        return exist;
    }

    Task<Contributor?> IContributorUpdateRepository.GetById(long contributorId)
    {
        throw new NotImplementedException();
    }

    public void Update(Contributor contributor)
    {
        throw new NotImplementedException();
    }

    Task<Contributor?> IContributorReadOnlyRepository.GetById(long contributorId)
    {
        throw new NotImplementedException();
    }
}