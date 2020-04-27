using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab15._2CreatingRestAPI.Models;
using Lab15._2CreatingRestAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab15._2CreatingRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class MovieController : ControllerBase
    {
        private IDAL dal;
        public MovieController(IDAL dalObject)
        {
            dal = dalObject;
        }

        [HttpDelete("{id}")]
        public Object Delete (int id)
        {
            int result = dal.DeleteMovieById(id);

            if (result > 0)
            {
                return new { success = true };
            }
            else
            {
                return new { success = false };
            }
        }

        [HttpGet("{id}")]
        public Movies GetSingleMovie(int id)
        {
            Movies movie = dal.GetMovieById(id);
            return movie;
        }

        [HttpGet]
        public IEnumerable<Movies> Get(string category = null)
        {
            if (category == null)
            {
                IEnumerable<Movies> Movies = dal.GetMoviesAll();
                return Movies; //serialize the parameter into JSON and return an Ok (20x)
            }
            else
            {
                IEnumerable<Movies> Movies = dal.GetMoviesByCategory(category);
                return Movies;
            }
        }


        [HttpGet("categories")]
        public string[] GetCategories()
        {
            return dal.GetMoviesCategories();
        }

        [HttpPost]
        public Object Post(Movies m)
        {
            int newId = dal.CreateMovie(m);
            if (newId < 0)
            {
                return new { success = false };
            }
            return new { status = true, id = newId };
        }
    }

}