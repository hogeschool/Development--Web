using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace my_first_app.Models
{

    public class MovieContext : DbContext
    {
        //this is actual entity object linked to the movies in our DB
        public DbSet<Movie> Movies { get; set; }
        //this is actual entity object linked to the actors in our DB
        public DbSet<Actor> Actors { get; set; }

        //this method is run automatically by EF the first time we run the application
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //here we define the name of our database
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=MovieDB;Pooling=true;");
        }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Actor> Actors { get; set; }
    }
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}