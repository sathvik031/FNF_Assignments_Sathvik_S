using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Movie
    {

        public int movieID { get; set; } = 100;
        public string MovieTitle { get; set; }
        public int movieRating { get; set; }

    }
    internal class Assignment5
    {
        static List<Movie> moviesList = new List<Movie>();

        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to movie records!");
            bool processing = true;
            string mName = "";
            do
            {
                string choice = ConsoleUtil.GetInputString("Enter your choice (add, remove, update, find, print) the movie by name").ToLower();
                if(choice == "add"|| choice == "remove" || choice == "update" || choice == "find")
                {
                    mName = ConsoleUtil.GetInputString("Enter the name of the movie").ToLower();
                }
                switch (choice)
                {
                    case "add":
                        AddMovie(mName);
                        break;
                    case "remove":
                        RemoveMovie(mName);
                        break;
                    case "update":
                        UpdateMovie(mName);
                        break;
                    case "find":
                        FindMovie(mName);
                        break;
                    case "print":
                        PrintMovies();
                        break;
                    default :
                        Console.WriteLine("Invalid choice try again.");
                        break;

                }
            } while (processing);

        }
        private static void PrintMovies()
        {
            if(moviesList.Count == 0)
            {
                Console.WriteLine("Movies list is empty. Try adding some movies.");
                return;
            }
            foreach (Movie movie in moviesList)
            {
                Console.WriteLine($"Movie ID: {movie.movieID} Movie name: {movie.MovieTitle} Movie Rating: {movie.movieRating}");
            }
        }

        private static void AddMovie(string mName)
        {
            Movie movie = new Movie();
            movie.movieID += 1;
            movie.MovieTitle = mName;
            int rating = ConsoleUtil.GetInputInt("Enter the rating for the movie");
            movie.movieRating = rating;
            moviesList.Add(movie);
        }

        private static void RemoveMovie(string mName)
        {
            if (moviesList.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            Movie curr = moviesList.Find(movie => movie.MovieTitle == mName);
            if (curr != null)
            {
                moviesList.Remove(curr);
            }
            else
            {
                Console.WriteLine("Movie not found");
            }
        }
        private static void UpdateMovie(string mName)
        {
            if (moviesList.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            Movie curr = moviesList.Find(movie => movie.MovieTitle == mName);
            string newName = ConsoleUtil.GetInputString("Enter the name to update");
            int newRating = ConsoleUtil.GetInputInt("Enter the rating to update");
            if (curr != null)
            {
                curr.MovieTitle = newName;
                curr.movieRating = newRating;
            }
            else
            {
                Console.WriteLine("Movie not found");
            }
        }
        private static void FindMovie(string mName)
        {
            if (moviesList.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            Movie curr = moviesList.Find(movie => movie.MovieTitle == mName);
            if (curr != null)
            {
                Console.WriteLine($" Movie Found! \nMovie ID: {curr.movieID} Movie name: {curr.MovieTitle} Movie Rating: {curr.movieRating}");
            }
            else
            {
                Console.WriteLine("Movie not found");
            }
        }
    }
}
