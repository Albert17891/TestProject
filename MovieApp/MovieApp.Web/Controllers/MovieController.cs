using Mapster;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using MovieApp.Web.Models.Request;

namespace MovieApp.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieRepository _repository;

    public MovieController(IMovieRepository repository)
    {
        _repository = repository;
    }

    [Route("get-by-id")]
    [HttpGet]
    public async Task<IActionResult> GetMovieById(int id, CancellationToken token = default)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var movie =await _repository.GetByIdAsync(id, token);

        return Ok(movie);
    }

    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token = default)
    {      

        var movies = await _repository.GetAllAsync(token);

        return Ok(movies);
    }

    [Route("add-movie")]
    [HttpPost]
    public async Task<IActionResult> AddMovie(MovieRequest movie,CancellationToken token)
    {
        if (movie == null)
        {
            return BadRequest();
        }

        await _repository.AddAsync(movie.Adapt<Movie>(), token);

        return Ok();
    }

    [Route("update-movie")]
    [HttpPut]
    public async Task<IActionResult> UpdateMovie(MovieUpdateRequest movie)
    {
        if (movie == null)
        {
            return BadRequest();
        }

        await _repository.UpdateAsync(movie.Adapt<Movie>());

        return Ok();
    }

    [Route("delete-movie")]
    [HttpDelete]
    public async Task<IActionResult> DeleteMovie(int id,CancellationToken token)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        await _repository.DeleteAsync(id, token);

        return Ok();
    }
}
