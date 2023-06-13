using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities.MovieModels;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _service;

    public MovieController(IMovieService service)
    {
        _service = service;
    }

    [Route("id{id}")]
    [HttpGet]
    public async Task<IActionResult> GetMovieById([FromRoute] int id, CancellationToken token = default)
    {
        var movie = await _service.GetMovieByIdAsync(id, token);

        return Ok(movie);
    }

    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token = default)
    {
        var movies = await _service.GetAllMovieAsync(token);

        return Ok(movies);
    }

    [Route("add-movie")]
    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] MovieRequest movie, CancellationToken token)
    {
        var result = await _service.AddMovieAsync(movie, token);

        if (result)
            return Ok();

        return BadRequest();
    }

    [Route("update-movie")]
    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] MovieUpdateRequest movie)
    {
        var result = await _service.UpdateMovieAsync(movie);

        if (result)
            return Ok();

        return BadRequest();
    }

    [Route("id/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteMovie([FromRoute] int id, CancellationToken token)
    {
        var result = await _service.DeleteMovieAsync(id, token);

        if (result)
            return Ok();

        return BadRequest();
    }
}