using System.Text.Json;
using TP3.Models;

namespace TP3.Services
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationdbContext _db;
        public GenreRepository(ApplicationdbContext db)
        {
            _db = db;
        }
        public ICollection<Genre> Genres()
        {

            return _db.Genre.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _db.Genre.FirstOrDefault(c=>c.Id==id);
        }
        public Genre AddGenre(Genre genre)
        {
            _db.Genre.Add(genre);
            _db.SaveChanges();
            return genre;
        }

    }
}
