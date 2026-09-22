using RecordShop.Data;
using RecordShop.Models;
using RecordShop.Repositories;
using Microsoft.EntityFrameworkCore;


namespace RecordShop.Tests;

public class AlbumRepositoryTests
{
    [Fact]
    public async Task GetAllAlbumsAsync_ReturnsAllAlbums()
    {
        //fake db
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestRepositoryDatabase")
            .Options;

        //add test data
        using (var context = new AppDbContext(options))
        {
            context.Albums.Add(new Album { AlbumId = 1, AlbumTitle = "A discovery of witches", ArtistId = 1, ReleaseDate = DateTime.Now, Stock = 10 });
            context.Albums.Add(new Album { AlbumId = 2, AlbumTitle = "Dune", ArtistId = 2, ReleaseDate = DateTime.Now, Stock = 5 });
            await context.SaveChangesAsync();
        }
        
        //creating repository and testing the GetAllAlbumsAsync method
        using (var context = new AppDbContext(options))
        {
            var repository = new AlbumRepository(context);
            var albums = await repository.GetAllAlbumsAsync();

            Assert.Equal(2, albums.Count);
            Assert.Equal("A discovery of witches", albums[0].AlbumTitle);
            Assert.Equal("Dune", albums[1].AlbumTitle);
        }

    }
}