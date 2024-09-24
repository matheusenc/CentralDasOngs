using System.ComponentModel.DataAnnotations;

namespace CentralDasOngs.Communication.Requests;

public class RequestRegisterContributorModel : RequestRegisterUserBaseModel
{
    [Display(Name = "CPF")]
    public string Cpf { get; set; }
}