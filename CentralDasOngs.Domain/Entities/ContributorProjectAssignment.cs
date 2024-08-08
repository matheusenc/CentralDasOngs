namespace CentralDasOngs.Domain.Entities;

public class ContributorProjectAssignment : EntityBase
{
    public long ContributorId { get; set; }
    public long ProjectId { get; set; }
}