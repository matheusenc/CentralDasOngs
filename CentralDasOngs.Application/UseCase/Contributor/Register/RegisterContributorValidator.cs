using CentralDasOngs.Communication.Requests;
using CentralDasOngs.Domain.Extensions;
using CentralDasOngs.Exceptions;
using FluentValidation;

namespace CentralDasOngs.Application.UseCase.Contributor.Register;

public class RegisterContributorValidator : AbstractValidator<RequestRegisterContributorModel>
{
    public RegisterContributorValidator()
    {
        RuleFor(user => user.Name).NotEmpty().MaximumLength(100).MinimumLength(2).WithMessage(ResourceMessagesError.NOME_INVALIDO);
        RuleFor(user => user.Email).NotEmpty().MaximumLength(254).MinimumLength(7).WithMessage(ResourceMessagesError.EMAIL_INVALIDO);
        When(user => user.Email.NotEmpty(), () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesError.EMAIL_INVALIDO);
        });
        RuleFor(user => user.Password).NotEmpty().MaximumLength(100).MinimumLength(8).WithMessage(ResourceMessagesError.SENHA_INVALIDA);
        RuleFor(user => user.RePassword).NotEmpty().Equal(user => user.Password).WithMessage(ResourceMessagesError.SENHA_NAO_COINCIDE);
        RuleFor(user => user.Description).MaximumLength(1000).WithMessage(ResourceMessagesError.DESCRICAO_INVALIDA);
        RuleFor(user => user.Cpf).NotEmpty().MaximumLength(14).WithMessage(ResourceMessagesError.CPF_INVALIDO);
        RuleFor(user => user.Country).NotEmpty().MaximumLength(56).MinimumLength(8).WithMessage(ResourceMessagesError.PAIS_INVALIDO);
        RuleFor(user => user.PostalCode).NotEmpty().MaximumLength(20).MinimumLength(8).WithMessage(ResourceMessagesError.CEP_INVALIDO);
        RuleFor(user => user.State).NotEmpty().MaximumLength(50).MinimumLength(2).WithMessage(ResourceMessagesError.ESTADO_INVALIDO);
        RuleFor(user => user.City).NotEmpty().NotEmpty().MaximumLength(100).MinimumLength(2).WithMessage(ResourceMessagesError.CIDADE_INVALIDA);
        RuleFor(user => user.Neighborhood).MaximumLength(100).WithMessage(ResourceMessagesError.REFERENCIA_INVALIDA);
        RuleFor(user => user.Street).MaximumLength(150).WithMessage(ResourceMessagesError.RUA_INVALIDA);
        RuleFor(user => user.Complement).NotEmpty().MaximumLength(100).MinimumLength(8).WithMessage(ResourceMessagesError.COMPLEMENTO_INVALIDO);
    }
}