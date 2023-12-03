using TP3.Models;

namespace TP3.Services
{
    public interface IGenreRepository
    {
        public ICollection<Genre> Genres();
        public Genre GetGenreById(int id);
        public Genre AddGenre(Genre genre);
    }
}
