using CoreBusiness;
using Plugins.DataStore.SQL;

namespace MoviesAPITests.Controllers;

[TestClass]
public class GenresSqlRepositoryTests: TestBase
{
    [TestMethod]
    public async Task Get_ReturnsAllOfTheGenres()
    {
        // Preparation
        var nameDb = Guid.NewGuid().ToString();
        var context = BuildContext(nameDb);
        var mapper = ConfigureAutoMapper();

        context.Genres.Add(new Genre { Name = "Genre 1" });
        context.Genres.Add(new Genre { Name = "Genre 2" });
        await context.SaveChangesAsync();

        var context2 = BuildContext(nameDb);
        var genresSqlRepository = new GenresSqlRepository(context2, mapper);
        
        // Testing
        var response = await genresSqlRepository.Get();
        
        // Verification
        Assert.AreEqual(expected: 2, actual: response.Count);
    }
}