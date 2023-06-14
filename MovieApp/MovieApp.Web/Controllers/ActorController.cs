using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.ActorModels;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly IActorService _service;

    public ActorController(IActorService service)
    {
        _service = service;
    }

    [Route("id/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetActorByIdAsync([FromRoute] int id, CancellationToken token = default)
    {
        var result = await _service.GetActorByIdAsync(id, token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound();
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.InternalServerError)
        {
            return StatusCode(500, result.Message);
        }

        return BadRequest(result);
    }

    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllActorAsync(token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound();
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.InternalServerError)
        {
            return StatusCode(500, result.Message);
        }

        return BadRequest(result);
    }

    [Route("add-actor")]
    [HttpPost]
    public async Task<IActionResult> AddActorAsync([FromBody] ActorRequest actor, CancellationToken token)
    {
        var result = await _service.AddActorAsync(actor, token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound();
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode(500, result.Message);
    }

    [Route("update-actor")]
    [HttpPut]
    public async Task<IActionResult> UpdateActorAsync([FromBody] ActorUpdateRequest actor)
    {
        var result = await _service.UpdateActorAsync(actor);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound();
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode(500, result.Message);
    }

    [Route("id/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteActorAsync([FromRoute] int id, CancellationToken token)
    {
        var result = await _service.DeleteActorAsync(id, token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound();
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode(500, result.Message);
    }
}