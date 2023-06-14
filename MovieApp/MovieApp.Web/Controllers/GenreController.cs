﻿using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities;
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

    [Route("id/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetGenreByIdAsync([FromRoute] int id, CancellationToken token = default)
    {
        var result = await _service.GetGenreByIdAsync(id, token);

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
        var result = await _service.GetAllGenreAsync(token);

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

    [Route("add-genre")]
    [HttpPost]
    public async Task<IActionResult> AddGenreAsync([FromBody] GenreRequest genre, CancellationToken token)
    {
        var result = await _service.AddGenreAsync(genre, token);

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

    [Route("update-genre")]
    [HttpPut]
    public async Task<IActionResult> UpdateGenreAsync([FromBody] GenreUpdateRequest genre)
    {
        var result = await _service.UpdateGenreAsync(genre);

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

    [Route("id/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteGenreAsync([FromRoute] int id, CancellationToken token)
    {
        var result = await _service.DeleteGenreAsync(id, token);

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
}