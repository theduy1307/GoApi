using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Application.Exceptions;
using MasterData.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MasterData.Application.Handlers;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Unit>
{
    private readonly ICountryRepository _countryRepository;
    private readonly ILogger<DeleteCountryCommandHandler> _logger;

    public DeleteCountryCommandHandler(ICountryRepository countryRepository, ILogger<DeleteCountryCommandHandler> logger)
    {
        _countryRepository = countryRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var countryToDelete = await _countryRepository.GetByIdAsync(request.Id);
        if (countryToDelete is null)
        {
            throw new CountryNotFoundException(nameof(Country), request.Id);
        }

        await _countryRepository.DeleteAsync(countryToDelete);
        _logger.LogInformation($"Country with {request.Id} is deleted");
        return Unit.Value;
    }
}