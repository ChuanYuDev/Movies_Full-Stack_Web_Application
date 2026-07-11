using CoreBusiness.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using MoviesAPI.Controllers;
using NSubstitute;
using UseCases.DataStoreInterfaces;

namespace MoviesAPITests.Controllers;

[TestClass]
public sealed class GenresControllerTests
{
    private const string CacheTag = "genres";
    
    [TestMethod]
    public async Task Get_ShouldReturn404_WhenGenreWithIdDoesNotExist()
    {
        var genresRepository = Substitute.For<IGenresRepository>();
        genresRepository.Get(Arg.Any<int>()).Returns((GenreDto?)null);
        
        var outputCacheStore = Substitute.For<IOutputCacheStore>();

        var genresController = new GenresController(genresRepository, outputCacheStore);
        var id = 1;

        var response = await genresController.Get(id);

        Assert.IsInstanceOfType<NotFoundResult>(response.Result);
    }

    [TestMethod]
    public async Task Post_ShouldCreateGenreAndInvokeEvictByTagAsync_WhenWeSendGenre()
    {
        var genresRepository = Substitute.For<IGenresRepository>();
        genresRepository.Add(Arg.Any<GenreCreationDto>()).Returns(new GenreDto{Name = "GenreDto"});
        
        var outputCacheStore = Substitute.For<IOutputCacheStore>();

        var genresController = new GenresController(genresRepository, outputCacheStore);

        var response = await genresController.Post(new GenreCreationDto { Name = "new genre" });

        Assert.IsInstanceOfType<CreatedAtRouteResult>(response);
        await outputCacheStore.Received(1).EvictByTagAsync(CacheTag, default);

    }
}