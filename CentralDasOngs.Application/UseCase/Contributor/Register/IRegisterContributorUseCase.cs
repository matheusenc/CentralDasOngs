using CentralDasOngs.Communication.Requests;

namespace CentralDasOngs.Application.UseCase.Contributor.Register;

public interface IRegisterContributorUseCase
{
    public Task<List<string>> Execute(RequestRegisterContributorModel model);
}