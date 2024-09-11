using CentralDasOngs.Domain.Entities;
using CentralDasOngs.Domain.Repositories.Category;
using Microsoft.EntityFrameworkCore;

namespace CentralDasOngs.Infrastructure.DataAccess.Repositories;

public class CategoryRepository : ICategoryReadOnlyRepository
{
    private readonly CentralDasOngsDbContext _dbContext;

    public CategoryRepository(CentralDasOngsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetById(long categoryId, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.FindAsync(categoryId, cancellationToken);
    }
}