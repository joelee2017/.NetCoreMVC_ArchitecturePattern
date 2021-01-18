using Microsoft.Extensions.DependencyInjection;
using Model.Models;
using Model.Repository;
using Service.Service;

namespace MvcMovie.Helper
{
    public static class InJectionExtension
    {
        public static void InJectionByRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Movie>, MovieRepository>();
        }

        public static void InJectionByService(this IServiceCollection services)
        {
            services.AddScoped<IMoviesService, MoviesService>();
        }
    }
}
