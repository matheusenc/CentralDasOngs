using CentralDasOngs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentralDasOngs.Infrastructure.DataAccess;

public class CentralDasOngsDbContext : DbContext
{
    public CentralDasOngsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<Ong> Ongs { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ContributorCategoryInterest> ContributorCategoryInterests { get; set; }
    public DbSet<ContributorProjectAssignment> ContributorProjectAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CentralDasOngsDbContext).Assembly);
    }
}