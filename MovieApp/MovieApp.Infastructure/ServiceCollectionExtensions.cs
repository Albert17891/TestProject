using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;
using MovieApp.Core.Services;
using MovieApp.Infastructure.Data;

namespace MovieApp.Infastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IGenreRepository,GenreRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();    

        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IActorService, ActorService>();

        return services;
    }
}