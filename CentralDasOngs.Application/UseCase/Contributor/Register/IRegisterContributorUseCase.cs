using CentralDasOngs.Communication.Requests;
using CentralDasOngs.Exceptions.Exceptions.ValidationError;

namespace CentralDasOngs.Application.UseCase.Contributor.Register;

public interface IRegisterContributorUseCase
{
    public Task<List<ValidationError>> Execute(RequestRegisterContributorModel model);
}