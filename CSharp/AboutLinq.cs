using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// to substitute xUnit's Assert class, to hide actual values
using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
	public class Movie
	{
		public string MovieTitle { get; set; }

		public string Category { get; set; }

		public int Minutes { get; set; }

		public int Year { get; set; }

		public string MainActor { get; set; }

		public decimal Rating { get; set; }
	}

	[Trait("Topic", "14 - About Linq")]
	public class AboutLinq : Koan
	{
		private List<Movie> GetShortMovieList()
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

		[Koan(1, DisplayName = "14.01 - Where method returns a filtered collection")]
		public void WhereMethodReturnsAFilteredCollection()
		{
			var movies = GetShortMovieList();

			// Use lambda expressions for query criteria
			var dramaMovies = movies.Where(m => m.Category == "Drama");

			Assert.Equal(3, dramaMovies.Count());
			//Assert.Equal(FILL_ME_IN, dramaMovies.Count());

			var sb = new StringBuilder();

			foreach (var item in dramaMovies)
			{
				sb.Append($", {item.MovieTitle}");
			}

			var titles = sb.ToString();

			Assert.Equal(", The Shawshank Redemption, The Godfather, Schindler's List", titles);
			//Assert.Equal(FILL_ME_IN, titles);
		}

		[Koan(2, DisplayName = "14.02 - Select method can return a collection of one property")]
		public void SelectMethodCanReturnACollectionOfOneProperty()
		{
			var movies = GetShortMovieList();

			// Use lambda expressions to select properties
			var dramaMovieTitles = movies.Where(m => m.Category == "Drama").Select(m => m.MovieTitle);

			Assert.Equal("The Shawshank Redemption, The Godfather, Schindler's List", String.Join(", ", dramaMovieTitles));
			//Assert.Equal(FILL_ME_IN, String.Join(",", dramaMovieTitles));
		}

		[Koan(3, DisplayName = "14.03 - Select method can return a collection of new objects")]
		public void SelectMethodCanReturnACollectionOfNewObjects()
		{
			var movies = GetShortMovieList();

			// Lambda expressions for select can create anonymous objects
			var dramaMovies = movies.Where(m => m.Category == "Drama").Select(m => new { Title = m.MovieTitle, Year = m.Year });

			var sb = new StringBuilder();

			foreach (var item in dramaMovies)
			{
				sb.AppendLine($"{item.Title} ({item.Year})");
			}

			var titles = sb.ToString();

			Assert.Equal("The Shawshank Redemption (1994)\r\nThe Godfather (1972)\r\nSchindler's List (1993)\r\n", titles);
			//Assert.Equal(FILL_ME_IN, titles);
		}

		[Koan(4, DisplayName = "14.04 - Where method can receive several conditions")]
		public void WhereMethodCanReceiveSeveralConditions()
		{
			var movies = GetShortMovieList();

			var drama1994Movies = movies.Where(m => m.Category == "Drama" && m.Year == 1994);

			Assert.Equal(1, drama1994Movies.Count());
			//Assert.Equal(FILL_ME_IN, drama1994Movies.Count());
		}

		[Koan(5, DisplayName = "14.05 - Where methods can be chained")]
		public void WhereMethodsCanBeChained()
		{
			var movies = GetShortMovieList();

			var dramaMovies = movies.Where(m => m.Category == "Drama").Where(m => m.Year == 1972);

			Assert.Equal("The Godfather", dramaMovies.ToArray()[0].MovieTitle);
			//Assert.Equal(FILL_ME_IN, dramaMovies.ToArray()[0].MovieTitle);
		}

		[Koan(6, DisplayName = "14.06 - FirstOrDefault method can return the first item")]
		public void FirstOrDefaultMethodCanReturnTheFirstItem()
		{
			var movies = GetShortMovieList();

			var dramaMovie1 = movies.SingleOrDefault(m => m.Category == "Drama" && m.Year == 2000);

			Assert.Null(dramaMovie1);
			//Assert.NotNull(dramaMovie1);

			var dramaMovie2 = movies.SingleOrDefault(m => m.Category == "Drama" && m.Year == 1994);

			Assert.Equal(typeof(Movie), dramaMovie2.GetType());
			//Assert.Equal(typeof(FillMeIn), dramaMovie2.GetType());

			var dramaMovie3 = movies.FirstOrDefault(m => m.Category == "Drama");

			Assert.Equal("The Shawshank Redemption", dramaMovie3.MovieTitle);
			//Assert.Equal(FILL_ME_IN, dramaMovie3.MovieTitle);
		}

		[Koan(7, DisplayName = "14.07 - SingleOrDefault method can return a single item")]
		public void SingleOrDefaultMethodCanReturnASingleItem()
		{
			var movies = GetShortMovieList();

			var dramaMovie1 = movies.FirstOrDefault(m => m.Category == "Drama" && m.Year == 2000);

			Assert.Null(dramaMovie1);
			//Assert.NotNull(drama2000Movie);

			var dramaMovie2 = movies.FirstOrDefault(m => m.Category == "Drama" && m.Year == 1994);

			Assert.Equal("The Shawshank Redemption", dramaMovie2.MovieTitle);
			//Assert.Equal(FILL_ME_IN, dramaMovie2.MovieTitle);

			try
			{
				var dramaMovie3 = movies.SingleOrDefault(m => m.Category == "Drama");
			}
			catch (Exception ex)
			{
				Assert.True(ex is Exception);
				//Assert.True(ex is FillMeInException);
			}
		}

		[Koan(8, DisplayName = "14.08 - Contains method can resolve subqueries")]
		public void ContainsMethodsCanResolveSubQueries()
		{
			var movies = GetShortMovieList();

			var seventies = movies.Where(m => m.Year < 1980 && m.Year >= 1970).Select(m => m.Year);

			Assert.Equal(2, seventies.Count());
			//Assert.Equal(FILL_ME_IN, years.Count());

			var seventiesDramaMovies = movies.Where(m => m.Category == "Drama" && seventies.Contains(m.Year));

			Assert.Equal("The Godfather", seventiesDramaMovies.FirstOrDefault().MovieTitle);
			//Assert.Equal(FILL_ME_IN, seventiesDramaMovies.FirstOrDefault().MovieTitle);
		}

		// Join
		// Union
		// Minus
		// Intersect
		// SelectMany

		private List<Movie> GetMovieList()
		{
			var list = new List<Movie> {
				new Movie { MovieTitle = "The Shawshank Redemption", Category = "Drama", Minutes = 142, Year = 1994, MainActor = "Tim Robbins", Rating = 9.2m },
				new Movie { MovieTitle = "The Godfather", Category = "Drama", Minutes = 175, Year = 1972, MainActor = "Marlon Brando", Rating = 9.2m },
				new Movie { MovieTitle = "Pulp Fiction", Category = "Thriller", Minutes = 154, Year = 1994, MainActor = "John Travolta", Rating = 8.9m },
				new Movie { MovieTitle = "Schindler's List", Category = "Drama", Minutes = 195, Year = 1993, MainActor = "Liam Neeson", Rating = 8.9m },
				new Movie { MovieTitle = "12 Angry Men", Category = "Drama", Minutes = 96, Year = 1957, MainActor = "Martin Balsam", Rating = 8.9m },
				new Movie { MovieTitle = "One Flew Over the Cuckoo's Nest", Category = "Drama", Minutes = 133, Year = 1975, MainActor = "Jack Nicholson", Rating = 8.8m },
				new Movie { MovieTitle = "The Dark Knight", Category = "Action", Minutes = 152, Year = 2008, MainActor = "Christian Bale", Rating = 8.8m },
				new Movie { MovieTitle = "The Lord of the Rings: The Return of the King", Category = "Action", Minutes = 201, Year = 2003, MainActor = "Elijah Wood", Rating = 8.8m },
				new Movie { MovieTitle = "Star Wars", Category = "Action", Minutes = 121, Year = 1977, MainActor = "Mark Hamill", Rating = 8.8m },
				new Movie { MovieTitle = "Casablanca", Category = "Drama", Minutes = 102, Year = 1942, MainActor = "Humphrey Bogart", Rating = 8.8m },
				new Movie { MovieTitle = "Goodfellas", Category = "Drama", Minutes = 146, Year = 1990, MainActor = "Robert De Niro", Rating = 8.8m },
				new Movie { MovieTitle = "Raiders of the Lost Ark", Category = "Action", Minutes = 115, Year = 1981, MainActor = "Harrison Ford", Rating = 8.7m },
				new Movie { MovieTitle = "Rear Window", Category = "Thriller", Minutes = 112, Year = 1954, MainActor = "James Stewart", Rating = 8.7m },
				new Movie { MovieTitle = "The Matrix", Category = "Sci-Fi", Minutes = 136, Year = 1999, MainActor = "Keanu Reeves", Rating = 8.6m },
				new Movie { MovieTitle = "It's a Wonderful Life", Category = "Family", Minutes = 130, Year = 1946, MainActor = "James Stewart", Rating = 8.6m },
				new Movie { MovieTitle = "Dr. Strangelove", Category = "Comedy", Minutes = 93, Year = 1964, MainActor = "Peter Sellers", Rating = 8.6m },
				new Movie { MovieTitle = "North by Northwest", Category = "Action", Minutes = 131, Year = 1959, MainActor = "Cary Grant", Rating = 8.6m },
				new Movie { MovieTitle = "Citizen Kane", Category = "Drama", Minutes = 119, Year = 1941, MainActor = "Orson Welles", Rating = 8.6m },
				new Movie { MovieTitle = "Forrest Gump", Category = "Comedy", Minutes = 142, Year = 1994, MainActor = "Tom Hanks", Rating = 8.6m },
				new Movie { MovieTitle = "Monty Python and the Holy Grail", Category = "Comedy", Minutes = 91, Year = 1975, MainActor = "Graham Chapman", Rating = 8.4m },
				new Movie { MovieTitle = "Up", Category = "Family", Minutes = 96, Year = 2009, MainActor = "Edward Asner", Rating = 8.4m },
				new Movie { MovieTitle = "Singin' in the Rain", Category = "Musical", Minutes = 103, Year = 1952, MainActor = "Gene Kelly", Rating = 8.4m },
				new Movie { MovieTitle = "2001: A Space Odyssey", Category = "Sci-Fi", Minutes = 141, Year = 1968, MainActor = "Keir Dullea", Rating = 8.4m },
				new Movie { MovieTitle = "Back to the Future", Category = "Family", Minutes = 116, Year = 1985, MainActor = "Michael J. Fox", Rating = 8.3m },
				new Movie { MovieTitle = "All About Eve", Category = "Drama", Minutes = 138, Year = 1951, MainActor = "Bette Davis", Rating = 8.3m },
				new Movie { MovieTitle = "The Wizard of Oz", Category = "Musical", Minutes = 101, Year = 1939, MainActor = "Judy Garland", Rating = 8.2m },
				new Movie { MovieTitle = "Ratatouille", Category = "Family", Minutes = 111, Year = 2007, MainActor = "Patton Oswalt", Rating = 8.1m },
				new Movie { MovieTitle = "Monsters, Inc.", Category = "Family", Minutes = 92, Year = 2001, MainActor = "John Goodman", Rating = 7.9m }
			};

			return list;
		}
	}
}
