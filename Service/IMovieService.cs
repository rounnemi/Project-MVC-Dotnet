using Microsoft.AspNetCore.Mvc.Rendering;
using TP3.Models;

namespace TP3.Service
{
    public interface IMovieService
    {
        public ICollection<Movie> GetAll();
        public Movie GetById(int id);
        public Movie Add(Movie movie);
        public Movie Update(Movie movie);
        public void DeleteById(int id);
        public IEnumerable<SelectListItem> Create();
        public ICollection<Movie> GetByGenre(int genreId);
        public ICollection<Movie> GetMovieOrdreCroissant();
    }
}
