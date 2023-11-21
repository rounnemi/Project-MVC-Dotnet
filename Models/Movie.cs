using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string ? Title { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public ICollection<Customer> ? Customer { get; set; }
    }
}
