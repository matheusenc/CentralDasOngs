using CentralDasOngs.Application.Services.AutoMapper;
using CentralDasOngs.Application.UseCase.Category.GetAll;
using CentralDasOngs.Application.UseCase.Category.GetById;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sqids;

namespace CentralDasOngs.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddUseCases(services);
        AddAutoMapper(services);
        AddIdEncoder(services, configuration);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(autoMapperOption =>
        {
            var sqids = option.GetService<SqidsEncoder<long>>()!;
            autoMapperOption.AddProfile(new AutoMapping(sqids));
        }).CreateMapper());
    }

    private static void AddIdEncoder(IServiceCollection services, IConfiguration configuration)
    {
        var sqids = new SqidsEncoder<long>(new()
        {
            MinLength = 3,
            Alphabet = configuration.GetValue<string>("Settings:IdCryptographyAlphabet")!
        });

        services.AddSingleton(sqids);
    }
    
    private static void AddUseCases( IServiceCollection services)
    {
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
        services.AddScoped<IGetAllCateogoriesUseCase, GetAllCategoriesUseCase>();
        
    }
}