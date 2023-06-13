using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities.ActorModels;
using MovieApp.Core.Entities.MovieModels;
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

    [Route("id{id}")]
    [HttpGet]
    public async Task<IActionResult> GetActorById([FromRoute] int id, CancellationToken token = default)
    {
        var movie = await _service.GetActorByIdAsync(id, token);

        return Ok(movie);
    }

    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token = default)
    {
        var movies = await _service.GetAllActorAsync(token);

        return Ok(movies);
    }

    [Route("add-actor")]
    [HttpPost]
    public async Task<IActionResult> AddActor([FromBody] ActorRequest actor, CancellationToken token)
    {
        var result = await _service.AddActorAsync(actor, token);

        if (result)
            return Ok();

        return BadRequest();
    }

    [Route("update-actor")]
    [HttpPut]
    public async Task<IActionResult> UpdateActor([FromBody] ActorUpdateRequest actor)
    {
        var result = await _service.UpdateActorAsync(actor);

        if (result)
            return Ok();

        return BadRequest();
    }

    [Route("id/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteActor([FromRoute] int id, CancellationToken token)
    {
        var result = await _service.DeleteActorAsync(id, token);

        if (result)
            return Ok();

        return BadRequest();
    }
}
