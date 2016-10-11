using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetKoans.CSharp
{
    public class Movie
    {
        public string MovieTitle { get; set; }

        public string Category { get; set; }

        public int Year { get; set; }
    }

    [Trait("Language", "C#")]
    [Trait("Topic", "C#-13 - About Linq")]
    public class AboutLinq : Koan
    {
        private List<Movie> GetMovieList()
        {
            var list = new List<Movie> {
                new Movie { MovieTitle = "The Shawshank Redemption", Category = "Drama", Year = 1994 },
                new Movie { MovieTitle = "The Godfather", Category = "Drama", Year = 1972 },
                new Movie { MovieTitle = "Pulp Fiction", Category = "Thriller", Year = 1994 },
                new Movie { MovieTitle = "Schindler's List", Category = "Drama", Year = 1993 },
                new Movie { MovieTitle = "Star Wars", Category = "Action", Year = 1977 },
            };

            return list;
        }

        [Koan(1, DisplayName = "13.01 - Where method returns a filtered collection")]
        public void WhereMethodReturnsAFilteredCollection()
        {
            var movies = GetMovieList();

            // Use lambda expressions for query criteria
            var dramaMovies = movies.Where(m => m.Category == "Drama");

            Assert.Equal(FILL_ME_IN, dramaMovies.Count());

            var sb = new StringBuilder();

            foreach (var item in dramaMovies)
            {
                sb.Append($", {item.MovieTitle}");
            }

            var titles = sb.ToString();

            Assert.Equal(FILL_ME_IN, titles);
        }

        [Koan(2, DisplayName = "13.02 - Select method can return a collection of one property")]
        public void SelectMethodCanReturnACollectionOfOneProperty()
        {
            var movies = GetMovieList();

            // Use lambda expressions to select properties
            var dramaMovieTitles = movies.Where(m => m.Category == "Drama").Select(m => m.MovieTitle);

            Assert.Equal(FILL_ME_IN, String.Join(",", dramaMovieTitles));
        }

        [Koan(3, DisplayName = "13.03 - Select method can return a collection of new objects")]
        public void SelectMethodCanReturnACollectionOfNewObjects()
        {
            var movies = GetMovieList();

            // Lambda expressions for select can create anonymous objects
            var dramaMovies = movies.Where(m => m.Category == "Drama").Select(m => new { Title = m.MovieTitle, Year = m.Year });

            var sb = new StringBuilder();

            foreach (var item in dramaMovies)
            {
                sb.AppendLine($"{item.Title} ({item.Year})");
            }

            var titles = sb.ToString();

            Assert.Equal(FILL_ME_IN, titles);
        }

        [Koan(4, DisplayName = "13.04 - Where method can receive several conditions")]
        public void WhereMethodCanReceiveSeveralConditions()
        {
            var movies = GetMovieList();

            var dramaMovies = movies.Where(m => m.Category == "Drama" && m.Year == 1994);

            Assert.Equal(FILL_ME_IN, dramaMovies.Count());
        }

        [Koan(5, DisplayName = "13.05 - Where methods can be chained")]
        public void WhereMethodsCanBeChained()
        {
            var movies = GetMovieList();

            var dramaMovies = movies.Where(m => m.Category == "Drama").Where(m => m.Year == 1972);

            Assert.Equal(FILL_ME_IN, dramaMovies.ToArray()[0].MovieTitle);
        }

        [Koan(6, DisplayName = "13.06 - FirstOrDefault method can return the first item")]
        public void FirstOrDefaultMethodCanReturnTheFirstItem()
        {
            var movies = GetMovieList();

            var dramaMovie1 = movies.SingleOrDefault(m => m.Category == "Drama" && m.Year == 2000);

            Assert.NotNull(dramaMovie1);

            var dramaMovie2 = movies.SingleOrDefault(m => m.Category == "Drama" && m.Year == 1994);

            Assert.Equal(typeof(FillMeIn), dramaMovie2.GetType());

            var dramaMovie3 = movies.FirstOrDefault(m => m.Category == "Drama");

            Assert.Equal(FILL_ME_IN, dramaMovie3.MovieTitle);
        }

        [Koan(7, DisplayName = "13.07 - SingleOrDefault method can return a single item")]
        public void SingleOrDefaultMethodCanReturnASingleItem()
        {
            var movies = GetMovieList();

            var dramaMovie1 = movies.FirstOrDefault(m => m.Category == "Drama" && m.Year == 2000);

            Assert.NotNull(dramaMovie1);

            var dramaMovie2 = movies.FirstOrDefault(m => m.Category == "Drama" && m.Year == 1994);

            Assert.Equal(FILL_ME_IN, dramaMovie2.MovieTitle);

            try
            {
                var dramaMovie3 = movies.SingleOrDefault(m => m.Category == "Drama");
            }
            catch (Exception ex)
            {
                Assert.True(ex is FillMeInException);
            }
        }

        [Koan(8, DisplayName = "13.08 - Contains method can resolve subqueries")]
        public void ContainsMethodsCanResolveSubQueries()
        {
            var movies = GetMovieList();

            var seventies = movies.Where(m => m.Year < 1980 && m.Year >= 1970).Select(m => m.Year);

            Assert.Equal(FILL_ME_IN, seventies.Count());

            var seventiesDramaMovies = movies.Where(m => m.Category == "Drama" && seventies.Contains(m.Year));

            Assert.Equal(FILL_ME_IN, seventiesDramaMovies.FirstOrDefault().MovieTitle);
        }

    }
}
