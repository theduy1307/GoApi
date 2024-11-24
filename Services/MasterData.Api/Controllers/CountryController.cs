using System.Net;
using MasterData.Application.Commands;
using MasterData.Application.Queries;
using MasterData.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

public class CountryController : ApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<CountryController> _logger;

    public CountryController(IMediator mediator, ILogger<CountryController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CountryResponse>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CountryResponse>>> GetCountryByName([FromQuery] string countryName)
    {
        var query = new GetCountryListQuery(countryName);
        var countries = await _mediator.Send(query);
        return Ok(countries);
    }

    [HttpPost(Name = "CreateCountry")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateCountry([FromBody] CreateCountryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateCountry")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> UpdateCountry([FromBody] UpdateCountryCommand command)
    {
        var result = await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteCountry")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCountry(Guid id)
    {
        var cmd = new DeleteCountryCommand(){Id = id};
        await _mediator.Send(cmd);
        return NoContent();

    }
}