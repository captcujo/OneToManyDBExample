using OneToManyDBExample.Interfaces;
using OneToManyDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToManyDBExample.Services
{
    public class MovieService: IMovieService
    {

        private ICategoryService _catSer;

        private IGenericRespository _repo;

        public MovieService(IGenericRespository repo,ICategoryService catSer)
        {
            this._repo = repo;
            this._catSer = catSer;
        }

        public List<Movie> ListMovies()
        {
            List<Movie> movies = (from m in _repo.Query<Movie>()
                                select new Movie
                                {
                                    Id = m.Id,
                                    Title = m.Title,
                                    Director = m.Director,
                                    Catagory = m.Catagory

                                }).ToList();
            return movies;
        }

        public Movie GetMovie(int id)
        {
            Movie movie = (from m in _repo.Query<Movie>()
                           where m.Id == id
                           select new Movie
                           {
                               Id = m.Id,
                               Title = m.Title,
                               Director = m.Director,
                               Catagory = m.Catagory
                           }).FirstOrDefault();
            return movie;
        }

        public void AddMovie(Movie movie)
        {
            Catagory category = _catSer.getCategoryWithoutMoives(movie.Catagory.Id);

            movie.Catagory = category;

            _repo.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            Catagory category = _catSer.getCategoryWithoutMoives(movie.Catagory.Id);

            movie.Catagory = category;

            _repo.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            Movie movieToDelete = (from m in _repo.Query<Movie>()
                                   where m.Id == id
                                   select m).FirstOrDefault();

           _repo.Delete(movieToDelete);
        }
    }
}
