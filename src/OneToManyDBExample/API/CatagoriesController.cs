using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneToManyDBExample.Data;
using OneToManyDBExample.Models;
using OneToManyDBExample.Interfaces;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToManyDBExample.API
{
    [Route("api/[controller]")]
    public class CatagoriesController : Controller
    {
        private ICategoryService _catSer;

        public CatagoriesController(ICategoryService catSer)
        {
            _catSer = catSer;
        }

        [HttpGet] 
        public List<Catagory> Get()
        {
            return _catSer.ListCategories();
        }

        [HttpGet("{id}")]
        public Catagory Get(int id)
        {
            return _catSer.GetCategory(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Catagory inCategory)
        {
            if ( inCategory == null) // Bad Category object ( empty )
            {
                return BadRequest();
            }
            else if (inCategory.Id == 0) // if incoming id is zero, it is a new Category
            {
                _catSer.AddCategory(inCategory);

                return Ok();
            }
            else // else if not a new Category, update existing Category
            {
                _catSer.UpdateCategory(inCategory);

                return Ok();

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _catSer.DeleteCategory(id);

            return Ok();
        }
    }
}

//private IGenericRespository _repo;
//List<Catagory> cat = (from c in _repo.Query<Catagory>()
//                      select new Catagory
//                      {
//                          Id = c.Id,
//                          Name = c.Name,
//                          Movies = c.Movies
//                      }).ToList();

//List<Catagory> cat = _repo.Query<Catagory>().Include(c => c.Movie).ToList();

//Catagory movies = (from c in _repo.Query<Catagory>()
//                  where c.Id == id
//                  select new Catagory
//                  {
//                      Id = c.Id,
//                      Name = c.Name,
//                      Movies = c.Movies
//                  }).FirstOrDefault();
//return movies;