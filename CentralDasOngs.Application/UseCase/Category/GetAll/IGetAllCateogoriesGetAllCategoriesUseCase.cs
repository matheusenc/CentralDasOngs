using CentralDasOngs.Communication.Responses;

namespace CentralDasOngs.Application.UseCase.Category.GetAll;

public interface IGetAllCateogoriesUseCase
{
    Task<List<ResponseCategory>> Execute(CancellationToken cancellationToken);
}