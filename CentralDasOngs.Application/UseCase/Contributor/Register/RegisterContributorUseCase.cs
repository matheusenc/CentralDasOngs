using AutoMapper;
using CentralDasOngs.Communication.Requests;
using CentralDasOngs.Domain.Repositories;
using CentralDasOngs.Domain.Repositories.Contributor;
using CentralDasOngs.Exceptions;
using CentralDasOngs.Exceptions.Exceptions.ValidationError;
using FluentValidation.Results;
using System.Diagnostics.Contracts;

namespace CentralDasOngs.Application.UseCase.Contributor.Register;

public class RegisterContributorUseCase : IRegisterContributorUseCase
{
    private readonly IContributorReadOnlyRepository _readOnlyRepository;
    private readonly IContributorWriteOnlyRepository _writeOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterContributorUseCase(IContributorReadOnlyRepository readOnlyRepository, IContributorWriteOnlyRepository writeOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ValidationError>> Execute(RequestRegisterContributorModel model)
    {
        var errorList = await Validate(model);
        if(errorList.Count != 0)
        {
            return errorList;
        }
        var contributor = _mapper.Map<Domain.Entities.Contributor>(model);
        await _writeOnlyRepository.Add(contributor);
        await _unitOfWork.Commit();
        return errorList;
    }

    private async Task<List<ValidationError>> Validate(RequestRegisterContributorModel model)
    {
        var validator = new RegisterContributorValidator();
        var result = await validator.ValidateAsync(model);
        var emailExist = await _readOnlyRepository.ExistActiveUserWithEmail(model.Email);
        if (emailExist) 
        {
            result.Errors.Add(new ValidationFailure(nameof(model.Email), ResourceMessagesError.EMAIL_JA_CADASTRADO));
        }

        if(result.IsValid) return [];

        var errorMessages = result.Errors.Select(e => new ValidationError
        {
            PropertyName = e.PropertyName,
            ErrorMessage = e.ErrorMessage
        }).ToList();
        return errorMessages;
    }
}