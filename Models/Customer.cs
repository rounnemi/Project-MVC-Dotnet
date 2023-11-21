namespace TP3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string? MembershiptypeID { get; set; }
        public membershiptype? membershiptype { get; set; }
        public ICollection<Movie>? movie { get; set; }

    }
}
