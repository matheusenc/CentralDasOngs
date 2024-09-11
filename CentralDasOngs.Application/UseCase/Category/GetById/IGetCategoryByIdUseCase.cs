using CentralDasOngs.Communication.Responses;

namespace CentralDasOngs.Application.UseCase.Category.GetById;

public interface IGetCategoryByIdUseCase
{
    Task<ResponseCategory?> Execute(string categoryId, CancellationToken cancellationToken);
}