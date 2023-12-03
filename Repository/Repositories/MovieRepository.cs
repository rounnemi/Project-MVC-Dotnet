using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Services
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ApplicationdbContext _db;
        public MovieRepository(ApplicationdbContext db)
        {
            _db = db;
        }
        public Movie Add(Movie movie)
        {
            if (movie.ImageFile != null && movie.ImageFile.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                movie.ImagePath = $"/images/{movie.ImageFile.FileName}";
            }
           
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        }

        public void DeleteById(int id)
        {
            _db.Movies.Remove(_db.Movies.FirstOrDefault(Movie => Movie.Id == id));
            _db.SaveChanges();

        }

        public ICollection<Movie> GetAll()
        {
            return _db.Movies.Include(m => m.Genre).ToList();

        }

        public Movie GetById(int id)
        {
            return _db.Movies.FirstOrDefault(Movie => Movie.Id == id);
        }

        public Movie Update(Movie movie)
        {
            _db.Movies.Update(movie);
            _db.SaveChanges();
            return movie;
        }
    }
}
