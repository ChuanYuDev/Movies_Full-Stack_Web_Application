using CoreBusiness;
using Plugins.DataStore.SQL;
using UseCases.FileStorageInterfaces;

namespace MoviesAPITests.SqlRepositories;

[TestClass]
public sealed class MoviesSqlRepositoryTests: TestBase
{
    [TestMethod]
    public async Task Get_ShouldReturnTwoGenres_GivenAMovieWithTwoGenres()
    {
        // Preparation
        var nameDb = Guid.NewGuid().ToString();
        var context = BuildContext(nameDb);
        var mapper = ConfigureAutoMapper();
        IFileStorage fileStorage = null!;

        var genre1 = new Genre { Name = "Genre 1" };
        var genre2 = new Genre { Name = "Genre 2" };

        var movie = new Movie
        {
            Title = "Movie 1",
            MoviesGenres = new List<MovieGenre>
            {
                new MovieGenre {Genre = genre1},
                new MovieGenre {Genre = genre2},
            }
        };

        context.Add(movie);
        await context.SaveChangesAsync();

        var context2 = BuildContext(nameDb);
        var moviesSqlRepository = new MoviesSqlRepository(context2, mapper, fileStorage);
        
        // Testing
        var movieDetailsDto = await moviesSqlRepository.Get(movie.Id);
        
        // Verification
        Assert.AreEqual(expected: 2, actual: movieDetailsDto?.Genres.Count);
    }
}