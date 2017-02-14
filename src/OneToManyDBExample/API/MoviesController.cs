using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneToManyDBExample.Data;
using OneToManyDBExample.Models;
using Microsoft.EntityFrameworkCore;
using OneToManyDBExample.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToManyDBExample.API
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private IMovieService _movSer;

        public MoviesController(IMovieService movSer)
        {
            _movSer = movSer;
        }

        [HttpGet]
        public List<Movie> Get()
        {
           return _movSer.ListMovies();
        }

        [HttpGet("{id}")] 
        public Movie Get(int id)
        {
            return _movSer.GetMovie(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie inMovie)
        {
            if (inMovie == null)        // Bad object ( empty )
            {
                return BadRequest();
            }
            else if (inMovie.Id == 0)   // if incoming id is zero, it is new
            {
                _movSer.AddMovie(inMovie);

                return Ok();
            }
            else                        // else if not a new, update existing
            {
                _movSer.UpdateMovie(inMovie);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        //public IActionResult Delete([FromBody]Movie movie)
        public IActionResult Delete(int id)
        {
            _movSer.DeleteMovie(id);

            return Ok();
        }
    }
}

//private IGenericRespository _repo;
//private ApplicationDbContext _db;

//List<Movie> movies = _db.Movies.Include(m => m.Catagory).ToList();

//List<Movie> mov = _repo.Query<Movie>().Include(m => m.Catagory).ToList();

//List<Movie> mov = (from m in _repo.Query<Movie>()
//                   select new Movie
//                   {
//                       Id = m.Id,
//                       Title = m.Title,
//                       Director = m.Director,
//                       Catagory = m.Catagory
//                   }).ToList();
//Movie movie = (from m in _repo.Query<Movie>()
//               where m.Id == id
//               select new Movie
//               {
//                   Id = m.Id,
//                   Title = m.Title,
//                   Director = m.Director,
//                   Catagory = m.Catagory
//               }).FirstOrDefault();

//public Catagory getCategory(int catId)
//{
//    Catagory category = (from c in _repo.Query<Catagory>()
//                         where c.Id == catId
//                         select c).FirstOrDefault();

//    return category;
//}

//Catagory cat = getCategory(inMovie.Catagory.Id);

//inMovie.Catagory = cat;

//_repo.Add<Movie>(inMovie);
//_repo.SaveChanges();

//var existingMovie = (from p in _repo.Query<Movie>()
//                       where p.Id == inMovie.Id
//                       select new
//                       {
//                           Catagory = p.Catagory
//                       }).FirstOrDefault();

//if( existingMovie.Catagory.Id != inMovie.Catagory.Id)
//{
//    Catagory cat = getCategory(inMovie.Catagory.Id);

//    inMovie.Catagory = cat;
//}

//_repo.Update(inMovie);
//_repo.SaveChanges();