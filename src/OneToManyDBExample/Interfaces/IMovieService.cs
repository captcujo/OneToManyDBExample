using System.Collections.Generic;
using OneToManyDBExample.Models;

namespace OneToManyDBExample.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        void DeleteMovie(int id);
        Movie GetMovie(int id);
        List<Movie> ListMovies();
        void UpdateMovie(Movie movie);
    }
}