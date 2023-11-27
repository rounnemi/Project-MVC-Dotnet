using Microsoft.AspNetCore.Mvc.Rendering;
using TP3.Models;
using TP3.Services;

namespace TP3.Service
{
    public class MovieService : IMovieService
    {
        public readonly IMovieRepository _MovieRepository;
        private readonly ApplicationdbContext _db;

        public MovieService( IMovieRepository movieRepository, ApplicationdbContext db)
        {
            _MovieRepository = movieRepository;
            _db = db;
        }
        public Movie Add(Movie movie)
        {
            return _MovieRepository.Add(movie);
        }

        public void DeleteById(int id)
        {
            _MovieRepository.DeleteById(id);

        }

        public ICollection<Movie> GetAll()
        {
            return _MovieRepository.GetAll();

        }

        public Movie GetById(int id)
        {
            return _MovieRepository.GetById(id);
        }

        public Movie Update(Movie movie)
        {

            return _MovieRepository.Update(movie);
        }

        public IEnumerable<SelectListItem> Create()
        {
            return _db.Genre.Select(members => new SelectListItem()
            {
                Text = members.GenreName.ToString(),
                Value = members.Id.ToString()
            });
        }
        public ICollection<Movie> GetByGenre(int genreId)
        {
            return _db.Movies.Where(movie => movie.GenreId == genreId).ToList();

        }
        public ICollection<Movie> GetMovieOrdreCroissant()
        {
            return _db.Movies.OrderBy(movie => movie.Title).ToList();

        }

    }
}
