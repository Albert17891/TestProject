using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.MovieModels;
using MovieApp.Core.Interfaces.Services;
using System.Net;

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

    [Route("id/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetMovieByIdAsync([FromRoute] int id, CancellationToken token = default)
    {
        var result = await _service.GetMovieByIdAsync(id, token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
    }

    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllMovieAsync(token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
    }

    [Route("add-movie")]
    [HttpPost]
    public async Task<IActionResult> AddMovieAsync([FromBody] MovieRequest movie, CancellationToken token)
    {
        var result = await _service.AddMovieAsync(movie, token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
    }

    [Route("update-movie")]
    [HttpPut]
    public async Task<IActionResult> UpdateMovieAsync([FromBody] MovieUpdateRequest movie)
    {
        var result = await _service.UpdateMovieAsync(movie);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
    }

    [Route("id/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteMovieAsync([FromRoute] int id, CancellationToken token)
    {
       var result= await _service.DeleteMovieAsync(id, token);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.NotFound)
        {
            return NotFound(result);
        }

        if (result.EnvelopeStatusCode == EnvelopeStatusCode.BadRequest)
        {
            return BadRequest(result);
        }

        return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
    }
}