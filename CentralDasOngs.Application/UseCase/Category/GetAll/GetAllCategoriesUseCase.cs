using AutoMapper;
using CentralDasOngs.Communication.Responses;
using CentralDasOngs.Domain.Repositories.Category;

namespace CentralDasOngs.Application.UseCase.Category.GetAll;

public class GetAllCategoriesUseCase : IGetAllCateogoriesUseCase
{
    private readonly ICategoryReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesUseCase(ICategoryReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResponseCategory>> Execute(CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAll(cancellationToken);
        
        var response = _mapper.Map<List<ResponseCategory>>(categories);
        
        return response;
    }
}