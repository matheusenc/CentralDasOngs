using AutoMapper;
using CentralDasOngs.Communication.Responses;
using CentralDasOngs.Domain.Entities;
using Sqids;

namespace CentralDasOngs.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    private readonly SqidsEncoder<long> _sqidsEncoder;

    public AutoMapping(SqidsEncoder<long> sqidsEncoder)
    {
        _sqidsEncoder = sqidsEncoder;
        RequestToDomain();
        DomainToResponse();
    }
    
    private void RequestToDomain()
    {
        
    }

    private void DomainToResponse()
    {
        CreateMap<Category, ResponseCategory>()
            .ForMember(dest =>dest.Id, config => config.MapFrom(source => _sqidsEncoder.Encode(source.Id)));
    }
}