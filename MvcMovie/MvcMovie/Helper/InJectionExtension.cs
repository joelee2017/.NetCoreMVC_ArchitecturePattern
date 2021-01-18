using Microsoft.Extensions.DependencyInjection;
using Model.Models;
using Model.Repository;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MvcMovie.Helper
{
    public static class InJectionExtension
    {
        public static void InJectionByRepository(this IServiceCollection services)
        {
            List<string> dataName = new List<string>() { "Repository" };
            Type[]  types = (from t in Assembly.Load("Model").GetExportedTypes()
                             where t.IsInterface
                             select t).ToArray(); 
            foreach (var item in types)
            {
                if (dataName.Contains(item.Name))
                {

                }
            }
            //Object obj = Activator.CreateInstance("Model", "Repository").Unwrap();
            //MethodInfo[] methods = obj.GetType().GetMethods(BindingFlags.Instance);
 

            //services.AddScoped<IRepository<Movie>, MovieRepository>();

            services.AddScoped<IRepository<Movie>, MovieRepository>();
        }

    public static void InJectionByService(this IServiceCollection services)
    {
        services.AddScoped<IMoviesService, MoviesService>();
    }
}
}
