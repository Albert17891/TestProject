﻿using MovieApp.Core.Entities;
using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Interfaces.Services;
public interface IMovieService
{
    Task<Envelope<MovieServiceModel>> GetMovieByIdAsync(int id, CancellationToken token);
    Task<IList<MovieServiceModel>> GetAllMovieAsync(CancellationToken token);
    Task AddMovieAsync(MovieRequest movie, CancellationToken token);
    Task UpdateMovieAsync(MovieUpdateRequest movie);
    Task DeleteMovieAsync(int id, CancellationToken token);
}
