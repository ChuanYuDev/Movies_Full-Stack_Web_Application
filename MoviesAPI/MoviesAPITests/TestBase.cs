using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using MoviesAPI.Utilities;
using NetTopologySuite;
using Plugins.DataStore.SQL;

namespace MoviesAPITests;

public class TestBase
{
    protected ApplicationDbContext BuildContext(string nameDb)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(nameDb).Options;

        return new ApplicationDbContext(options);
    }

    protected IMapper ConfigureAutoMapper()
    {
        var mapperConfiguration = new MapperConfiguration(config =>
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            
            config.AddProfile(new AutoMapperProfiles(geometryFactory));
        }, NullLoggerFactory.Instance);

        return mapperConfiguration.CreateMapper();
    }
}