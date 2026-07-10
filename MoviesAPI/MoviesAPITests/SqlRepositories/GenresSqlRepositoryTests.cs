using CoreBusiness;
using Plugins.DataStore.SQL;

namespace MoviesAPITests.SqlRepositories;

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
    
    [TestMethod]
    public async Task Get_ShouldReturnNull_WhenGenreWithIdDoesNotExist()
    {
        // Preparation
        var nameDb = Guid.NewGuid().ToString();
        var context = BuildContext(nameDb);
        var mapper = ConfigureAutoMapper();

        var genresSqlRepository = new GenresSqlRepository(context, mapper);
        var id = 1;
        
        // Testing
        var response = await genresSqlRepository.Get(id);
        
        // Verification
        Assert.AreEqual(expected: null, actual: response);
    }
    
    [TestMethod]
    public async Task Get_ShouldReturnTheGenre_WhenGenreWithIdExists()
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
        var id = 1;
        
        // Testing
        var response = await genresSqlRepository.Get(id);
        
        // Verification
        Assert.AreEqual(expected: id, actual: response?.Id);
    }
}