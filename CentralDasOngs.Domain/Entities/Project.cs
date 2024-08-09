using CentralDasOngs.Domain.Enums;

namespace CentralDasOngs.Domain.Entities;

public class Project : EntityBase
{
    public ProjectType Type { get; set; }
    public int ContributorCount { get; set; }
    public string Description { get; set; } = string.Empty;
    public long OngId { get; set; }
    public long CategoryId { get; set; }
    public string ImageIdentifier { get; set; } = string.Empty;
    public IList<ContributorProjectAssignment> ContributorProjectAssignments { get; set; } = [];
}