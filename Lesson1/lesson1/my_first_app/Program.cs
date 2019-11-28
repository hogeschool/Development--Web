using System;
using my_first_app.Models;
using System.Linq;

namespace my_first_app
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new MovieContext()){

                if(db.Movies.Count() == 0 && db.Actors.Count() == 0){
                    db.Movies.Add(new Movie(){
                        Title = "Titanic",
                        Actors = new System.Collections.Generic.List<Actor>() {
                            new Actor(){ Name = "Leonardo DiCaprio" }
                        }
                    });
                    db.SaveChanges();
                }
                else{
                    Console.WriteLine("Movies:");
                    foreach (var movie in db.Movies)
                    {
                        Console.WriteLine("Title: " + movie.Title);
                    }

                    Console.WriteLine("Actors:");
                    foreach (var actor in db.Actors)
                    {
                        Console.WriteLine("Name: " + actor.Name);
                    }
                }
            }

            Console.WriteLine("done");
        }
    }
}
