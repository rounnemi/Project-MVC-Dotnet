using Microsoft.AspNetCore.Mvc.Rendering;
using TP3.Models;

namespace TP3.Services
{
    public class MovieService : IMovieService
    {
        public readonly IMovieRepository _MovieRepository;
        private readonly ApplicationdbContext _db;

        public MovieService(IMovieRepository movieRepository, ApplicationdbContext db)
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
            //ici j'ai juste voulu utilisre le linqquery au lieu de le faire a travers les methodes du repository (tp4)
            return _db.Movies.Where(movie => movie.GenreId == genreId).ToList();

        }
        public ICollection<Movie> GetMovieOrdreCroissant()
        {
            //ici j'ai juste voulu utilisre le linqquery au lieu de le faire a travers les methodes du repository (tp4)

            return _db.Movies.OrderBy(movie => movie.Title).ToList();

        }

    }
}
