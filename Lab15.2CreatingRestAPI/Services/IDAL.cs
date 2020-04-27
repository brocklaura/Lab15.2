using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab15._2CreatingRestAPI.Models;

namespace Lab15._2CreatingRestAPI.Services
{
    public interface IDAL
    {
        int CreateMovie(Movies movie);
        int DeleteMovieById(int id);
        Movies GetMovieById(int id);

        string[] GetMoviesCategories();
        IEnumerable<Movies> GetMoviesAll();
        IEnumerable<Movies> GetMoviesByCategory(string category);
    }
}
