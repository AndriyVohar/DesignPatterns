using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR_1
{
    class TVShow
    {
        public string Title { get; set; }
        public List<string> Genres { get; set; }

        public TVShow(string title, List<string> genres)
        {
            Title = title;
            Genres = genres;
        }
    }
    interface SearchStrategy
    {
        List<TVShow> SearchShows(string genre);
    }
    class AmazonPrimeSearchStrategy : SearchStrategy
    {
        public List<TVShow> SearchShows(string genre)
        {
            List<TVShow> amazonPrimeShows = new List<TVShow>
            {
                new TVShow("The Shawshank Redemption", new List<string> { "Romance", "Drama" }),
                new TVShow("The Godfather", new List<string> { "Crime", "Drama" }),
                new TVShow("Pulp Fiction", new List<string> { "Crime", "Drama" }),
                new TVShow("The Dark Knight", new List<string> { "Action", "Crime" }),
                new TVShow("Schindler's List", new List<string> { "Biography", "Drama" }),
                new TVShow("Forrest Gump", new List<string> { "Drama", "Romance" }),
                new TVShow("The Matrix", new List<string> { "Action", "Sci-Fi" }),
                new TVShow("Fight Club", new List<string> { "Drama" }),
                new TVShow("Inception", new List<string> { "Action", "Adventure" }),
                new TVShow("The Silence of the Lambs", new List<string> { "Crime", "Drama" }),
                new TVShow("Seven", new List<string> { "Crime", "Mystery" }),
                new TVShow("The Lord of the Rings: The Return of the King", new List<string> { "Adventure", "Drama" }),
                new TVShow("Goodfellas", new List<string> { "Biography", "Crime" }),
                new TVShow("The Shawshank Redemption", new List<string> { "Romance", "Drama" }),
                new TVShow("The Shining", new List<string> { "Drama", "Horror" }),
                new TVShow("The Departed", new List<string> { "Crime", "Drama" }),
                new TVShow("Gladiator", new List<string> { "Action", "Adventure" }),
                new TVShow("The Green Mile", new List<string> { "Crime", "Drama" }),
                new TVShow("The Godfather: Part II", new List<string> { "Crime", "Drama" }),
                new TVShow("Casablanca", new List<string> { "Drama", "Romance" })
            };

            List<TVShow> findGenre = amazonPrimeShows.Where(show => show.Genres.Contains(genre)).ToList();
            return findGenre;
        }
    }
    class AppleTV : SearchStrategy
    {
        public List<TVShow> SearchShows(string genre)
        {
            List<TVShow> appleTVShows = new List<TVShow>
            {
                new TVShow("The Shawshank Redemption", new List<string> { "Romance", "Drama" }),
                new TVShow("The Godfather", new List<string> { "Crime", "Drama" }),
                new TVShow("Pulp Fiction", new List<string> { "Crime", "Drama" }),
                new TVShow("The Dark Knight", new List<string> { "Action", "Crime" }),
                new TVShow("Schindler's List", new List<string> { "Biography", "Drama" }),
                new TVShow("Forrest Gump", new List<string> { "Drama", "Romance" }),
                new TVShow("The Matrix", new List<string> { "Action", "Sci-Fi" }),
                new TVShow("Fight Club", new List<string> { "Drama" }),
                new TVShow("Inception", new List<string> { "Action", "Adventure" }),
                new TVShow("The Silence of the Lambs", new List<string> { "Crime", "Drama" }),
                new TVShow("Seven", new List<string> { "Crime", "Mystery" }),
                new TVShow("The Lord of the Rings: The Return of the King", new List<string> { "Adventure", "Drama" }),
                new TVShow("Goodfellas", new List<string> { "Biography", "Crime" }),
                new TVShow("The Shawshank Redemption", new List<string> { "Romance", "Drama" }),
                new TVShow("The Shining", new List<string> { "Drama", "Horror" }),
                new TVShow("The Departed", new List<string> { "Crime", "Drama" }),
                new TVShow("Gladiator", new List<string> { "Action", "Adventure" }),
                new TVShow("The Green Mile", new List<string> { "Crime", "Drama" }),
                new TVShow("The Godfather: Part II", new List<string> { "Crime", "Drama" }),
                new TVShow("Casablanca", new List<string> { "Drama", "Romance" })
            };
            return appleTVShows;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Використано шаблон - Стратегія (Strategy Pattern)

            //================================================
            
            Console.WriteLine("Вас вітає пошукова система \nВведіть назву жанру (Romance, Drama, Crime): ");
            string genreToSearch = Console.ReadLine();

            Console.WriteLine("Гаразд, тепер введіть на якій плаформі ви бажаєте шукати (Amazon Prime, Apple TV+, Netflix, Disney+): ");
            string platform = Console.ReadLine();

            SearchStrategy searchStrategy = null;
            if (platform == "Amazon Prime")
            {
                searchStrategy = new AmazonPrimeSearchStrategy();
            } else if (platform == "Apple TV+")
            {
                searchStrategy = new AppleTV();
            } else if (platform == "Netflix"|| platform == "Disney +")
            {
                Console.WriteLine("Вибачте, з плаформою {0} немає співпраці",platform);
            }
            else {
                new ArgumentException("Неправильна назва платформи");
            }
            List<TVShow> searchResults = searchStrategy.SearchShows(genreToSearch);
            foreach (TVShow show in searchResults)
            {
                Console.WriteLine($"Назва: {show.Title}, Жанри: {string.Join(", ", show.Genres)}");
            }

        }
    }
}
