using Model.Models;
using Nelibur.ObjectMapper;

namespace Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MapperConfig.Register();
        }

        public class MapperConfig
        {
            public static void Register()
            {
                TinyMapper.Bind<Movie, MovieViewModel>();
            }
        }
    }
}
