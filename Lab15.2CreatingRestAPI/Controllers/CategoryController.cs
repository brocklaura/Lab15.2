using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab15._2CreatingRestAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab15._2CreatingRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IDAL dal;
        public CategoryController(IDAL dalObject)
        {
            dal = dalObject;
        }
        [HttpGet]
        public string[] GetCategories()
        {
            return dal.GetMoviesCategories();
        }

    }
}