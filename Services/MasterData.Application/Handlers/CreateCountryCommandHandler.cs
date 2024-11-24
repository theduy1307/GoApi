using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MasterData.Application.Handlers;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Guid>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCountryCommandHandler> _logger;

    public CreateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper, ILogger<CreateCountryCommandHandler> logger)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var countryEntity = _mapper.Map<Country>(request);
        countryEntity.Id = Guid.NewGuid();
        var generatorCountry = await _countryRepository.AddAsync(countryEntity);
        _logger.LogInformation($"Country with Id {generatorCountry.Id} successfully created");
        return generatorCountry.Id;
    }
}