using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Core.Interfaces;
using MovieApp.Infastructure.Data;

namespace MovieApp.Infastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IMovieRepository, BaseRepository>();    

        return services;
    }
}
