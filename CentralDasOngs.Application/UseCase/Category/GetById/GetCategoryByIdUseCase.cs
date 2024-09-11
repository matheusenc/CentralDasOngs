using AutoMapper;
using CentralDasOngs.Communication.Responses;
using CentralDasOngs.Domain.Repositories.Category;
using Sqids;

namespace CentralDasOngs.Application.UseCase.Category.GetById;

public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
{
    private readonly ICategoryReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly SqidsEncoder<long> _sqidsEncoder;

    public GetCategoryByIdUseCase(ICategoryReadOnlyRepository repository, IMapper mapper, SqidsEncoder<long> sqidsEncoder)
    {
        _sqidsEncoder = sqidsEncoder;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseCategory?> Execute(string categoryId, CancellationToken cancellationToken)
    {
        //poderia ser utilizado o [0] diretamente ou First, porem a lista pode ser vazia, então temos o Default para
        //definir 0 para o tipo long
        var decodedCategoryId = _sqidsEncoder.Decode(categoryId).FirstOrDefault();
        var category = await _repository.GetById(decodedCategoryId, cancellationToken);

        if (category is null)
        {
            //colocar tratamento de exception.
            //Criar filtro na Presetattion e classes no Exceptions na Solução Shared 
        }

        var response = _mapper.Map<ResponseCategory>(category);
        return response;
    }
}