using AutoMapper;
using CentralDasOngs.Communication.Requests;
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
        CreateMap<RequestRegisterContributorModel, Contributor>()
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Country))
            .ForPath(dest => dest.Address.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.State))
            .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
            .ForPath(dest => dest.Address.Neighborhood, opt => opt.MapFrom(src => src.Neighborhood))
            .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
            .ForPath(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Number))
            .ForPath(dest => dest.Address.Complement, opt => opt.MapFrom(src => src.Complement));
    }

    private void DomainToResponse()
    {
        CreateMap<Category, ResponseCategory>()
            .ForMember(dest =>dest.Id, config => config.MapFrom(source => _sqidsEncoder.Encode(source.Id)));
    }
}