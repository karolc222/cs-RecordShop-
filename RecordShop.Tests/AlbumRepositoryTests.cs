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
        var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase(databaseName: "TestDatabase")
    .Options;
    
        using (var context = new AppDbContext(options))
        {
            context.Albums.Add(new Album { AlbumId = 1, AlbumTitle = "Test Album 1", ArtistId = 1, ReleaseDate = DateTime.Now, Stock = 10 });
            context.Albums.Add(new Album { AlbumId = 2, AlbumTitle = "Test Album 2", ArtistId = 2, ReleaseDate = DateTime.Now, Stock = 5 });
            await context.SaveChangesAsync();
        }

        using (var context = new AppDbContext(options))
        {
            var repository = new AlbumRepository(context);
            var albums = await repository.GetAllAlbumsAsync();

            Assert.Equal(2, albums.Count);
            Assert.Equal("Test Album 1", albums[0].AlbumTitle);
            Assert.Equal("Test Album 2", albums[1].AlbumTitle);
        }

    }
}