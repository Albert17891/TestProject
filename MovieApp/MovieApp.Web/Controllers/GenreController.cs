using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities.GenreModels;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    [Route("id{id}")]
    [HttpGet]
    public async Task<IActionResult> GetGenreById([FromRoute] int id, CancellationToken token = default)
    {
        var genre = await _service.GetGenreByIdAsync(id, token);

        return Ok(genre);
    }

    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token = default)
    {
        var genres = await _service.GetAllGenreAsync(token);

        return Ok(genres);
    }

    [Route("add-genre")]
    [HttpPost]
    public async Task<IActionResult> AddGenre([FromBody] GenreRequest genre, CancellationToken token)
    {
        var result = await _service.AddGenreAsync(genre, token);

        if (result)
            return Ok();

        return BadRequest();
    }

    [Route("update-genre")]
    [HttpPut]
    public async Task<IActionResult> UpdateGenre([FromBody] GenreUpdateRequest genre)
    {
        var result = await _service.UpdateGenreAsync(genre);

        if (result)
            return Ok();

        return BadRequest();
    }

    [Route("id/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteGenre([FromRoute] int id, CancellationToken token)
    {
        var result = await _service.DeleteGenreAsync(id, token);

        if (result)
            return Ok();

        return BadRequest();
    }
}
