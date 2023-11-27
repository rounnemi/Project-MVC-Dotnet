using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class ApplicationdbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<membershiptype> Memberships { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public ApplicationdbContext(DbContextOptions options)
        : base(options)
        {
        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                 .HasOne(m => m.Genre)   // One Genre
                 .WithMany(c => c.Movies)   // has Many Movies
                 .HasForeignKey(m => m.GenreId)   // Foreign key property in Movie
                 .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete if desired
            base.OnModelCreating(modelBuilder);
            // Chemin du fichier JSON



            base.OnModelCreating(modelBuilder);
            string genreJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Genre.json");

            string GenreJSon = System.IO.File.ReadAllText(genreJsonPath);
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            foreach (Genre c in genres)
                modelBuilder.Entity<Genre>()
                .HasData(c);

            base.OnModelCreating(modelBuilder);
            string MembershipJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Membership.json");

            string MembershipJSon = System.IO.File.ReadAllText(MembershipJsonPath);
            List<membershiptype>? membershiptypes = System.Text.Json.JsonSerializer.Deserialize<List<membershiptype>>(MembershipJSon);
            foreach (membershiptype c in membershiptypes)
                modelBuilder.Entity<membershiptype>()
                .HasData(c);

        }
     

    }
}
