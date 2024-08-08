namespace CentralDasOngs.Domain.Entities;

public class Ong : UserBase
{
    public string Cnpj { get; set; } = string.Empty;
    public IList<Project> Projects { get; set; } = [];
}