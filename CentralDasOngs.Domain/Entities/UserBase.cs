using System.Runtime.CompilerServices;

namespace CentralDasOngs.Domain.Entities;

public class UserBase : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageIdentifier { get; set; } = string.Empty;
    
    public long AddressId { get; set; }
    public Address Address { get; set; } = new Address();
}