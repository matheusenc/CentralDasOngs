using System.ComponentModel.DataAnnotations;

namespace CentralDasOngs.Communication.Requests;

public class RequestRegisterUserBaseModel
{
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
    [Display(Name = "Senha")]
    public string Password { get; set; } = string.Empty;
    [Display(Name = "Confirmação de senha")]
    public string RePassword { get; set; } = string.Empty;
    [Display(Name = "Descrição")]
    public string Description { get; set; } = string.Empty;
    [Display(Name = "País")]
    public string Country { get; set; } = string.Empty;
    [Display(Name = "CEP")]
    public string PostalCode { get; set; } = string.Empty;
    [Display(Name = "Estado")]
    public string State { get; set; } = string.Empty;
    [Display(Name = "Cidade")]
    public string City { get; set; } = string.Empty;
    [Display(Name = "Ponto de referencia")]
    public string Neighborhood { get; set; } = string.Empty;
    [Display(Name = "Rua")]
    public string Street { get; set; } = string.Empty;
    [Display(Name = "Numero")]
    public int Number { get; set; }
    [Display(Name = "Complemento")]
    public string Complement { get; set; } = string.Empty;
}