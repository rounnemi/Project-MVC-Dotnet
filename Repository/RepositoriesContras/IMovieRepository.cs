using TP3.Models;

namespace TP3.Services
{
    public interface IMovieRepository
    {
        public ICollection<Movie> GetAll();
        public Movie GetById(int id);
        public Movie Add(Movie movie);
        public Movie Update(Movie movie);
        public void DeleteById(int id);

    }
}
