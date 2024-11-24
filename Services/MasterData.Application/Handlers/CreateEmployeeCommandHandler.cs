using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MasterData.Application.Handlers;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateEmployeeCommandHandler> _logger;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<CreateEmployeeCommandHandler> logger)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeEntity = _mapper.Map<Employee>(request);
        employeeEntity.Id = Guid.NewGuid();
        var generatorCountry = await _employeeRepository.AddAsync(employeeEntity);
        _logger.LogInformation($"Country with Id {generatorCountry.Id} successfully created");
        return generatorCountry.Id;
    }
}