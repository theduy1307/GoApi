using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Application.Exceptions;
using MasterData.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MasterData.Application.Handlers;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Unit>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCountryCommandHandler> _logger;

    public UpdateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper, ILogger<UpdateCountryCommandHandler> logger)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var countryToUpdate = await _countryRepository.GetByIdAsync(request.Id);
        if (countryToUpdate is null)
        {
            throw new CountryNotFoundException(nameof(Country), request.Id);
        }

        _mapper.Map(request, countryToUpdate, typeof(UpdateCountryCommand), typeof(Country));
        await _countryRepository.UpdateAsync(countryToUpdate);
        _logger.LogInformation($"Country {countryToUpdate} is successfully updated");
        return Unit.Value;
    }
}