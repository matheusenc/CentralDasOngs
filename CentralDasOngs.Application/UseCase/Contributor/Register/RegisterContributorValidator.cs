using CentralDasOngs.Communication.Requests;
using CentralDasOngs.Domain.Extensions;
using CentralDasOngs.Exceptions;
using FluentValidation;

namespace CentralDasOngs.Application.UseCase.Contributor.Register;

public class RegisterContributorValidator : AbstractValidator<RequestRegisterContributorModel>
{
    public RegisterContributorValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage(ResourceMessagesError.NOME_INVALIDO)
            .MaximumLength(100).WithMessage(ResourceMessagesError.NOME_INVALIDO)
            .MinimumLength(2).WithMessage(ResourceMessagesError.NOME_INVALIDO);
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage(ResourceMessagesError.EMAIL_INVALIDO)
            .MaximumLength(254).WithMessage(ResourceMessagesError.EMAIL_INVALIDO)
            .MinimumLength(7).WithMessage(ResourceMessagesError.EMAIL_INVALIDO);
        When(user => user.Email.NotEmpty(), () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesError.EMAIL_INVALIDO);
        });
        RuleFor(user => user.Password)
            .NotEmpty().WithMessage(ResourceMessagesError.SENHA_INVALIDA)
            .MaximumLength(100).WithMessage(ResourceMessagesError.SENHA_INVALIDA)
            .MinimumLength(8).WithMessage(ResourceMessagesError.SENHA_INVALIDA);
        RuleFor(user => user.RePassword)
            .Equal(user => user.Password).WithMessage(ResourceMessagesError.SENHA_NAO_COINCIDE);
        RuleFor(user => user.Description)
            .MaximumLength(1000).WithMessage(ResourceMessagesError.DESCRICAO_INVALIDA);
        RuleFor(user => user.Cpf)
            .NotEmpty().WithMessage(ResourceMessagesError.CPF_INVALIDO)
            .MaximumLength(14).WithMessage(ResourceMessagesError.CPF_INVALIDO);
        RuleFor(user => user.Country)
            .NotEmpty().WithMessage(ResourceMessagesError.PAIS_INVALIDO)
            .MaximumLength(56).WithMessage(ResourceMessagesError.PAIS_INVALIDO)
            .MinimumLength(2).WithMessage(ResourceMessagesError.PAIS_INVALIDO);
        RuleFor(user => user.PostalCode)
            .NotEmpty().WithMessage(ResourceMessagesError.CEP_INVALIDO)
            .MaximumLength(20).WithMessage(ResourceMessagesError.CEP_INVALIDO)
            .MinimumLength(8).WithMessage(ResourceMessagesError.CEP_INVALIDO);
        RuleFor(user => user.State)
            .NotEmpty().WithMessage(ResourceMessagesError.ESTADO_INVALIDO)
            .MaximumLength(50).WithMessage(ResourceMessagesError.ESTADO_INVALIDO)
            .MinimumLength(2).WithMessage(ResourceMessagesError.ESTADO_INVALIDO);
        RuleFor(user => user.City)
            .NotEmpty().WithMessage(ResourceMessagesError.CIDADE_INVALIDA)
            .MaximumLength(100).WithMessage(ResourceMessagesError.CIDADE_INVALIDA)
            .MinimumLength(2).WithMessage(ResourceMessagesError.CIDADE_INVALIDA);
        RuleFor(user => user.Neighborhood).MaximumLength(100).WithMessage(ResourceMessagesError.REFERENCIA_INVALIDA);
        RuleFor(user => user.Street).MaximumLength(150).WithMessage(ResourceMessagesError.RUA_INVALIDA);
        RuleFor(user => user.Complement)
            .MaximumLength(100).WithMessage(ResourceMessagesError.COMPLEMENTO_INVALIDO)
            .MinimumLength(2).WithMessage(ResourceMessagesError.COMPLEMENTO_INVALIDO);
    }
}