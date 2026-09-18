//handles all database access, read and modify album data
using RecordShop.Data;
using RecordShop.Models;
using Microsoft.EntityFrameworkCore;


namespace RecordShop.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _context;

        //dependancy injection/context constructor
        public AlbumRepository(AppDbContext context)
        {
            _context = context;
        }


        //list all albums in stock 
        public async Task<List<Album>> GetAllAlbumsAsync()
        {
            return await _context.Albums.ToListAsync();
        }


        // get album by id 
        public async Task<Album?> GetAlbumByIdAsync(int id)
        {
            return await _context.Albums.FindAsync(id);
        }


        // add new album
        public async Task<Album> PostAlbumAsync(Album postedAlbum)
        {
            _context.Albums.Add(postedAlbum);
            await _context.SaveChangesAsync();

            return postedAlbum;
        }

        public async Task<Album?> PutAlbumAsync(int id, Album updatedAlbum)
        {
            var existingAlbum = await _context.Albums.FindAsync(id);

            if (existingAlbum == null)
            {
                return null;
            }

            existingAlbum.AlbumTitle = updatedAlbum.AlbumTitle;
            existingAlbum.ArtistId = updatedAlbum.ArtistId;
            existingAlbum.ReleaseDate = updatedAlbum.ReleaseDate;
            existingAlbum.Stock = updatedAlbum.Stock;

            await _context.SaveChangesAsync();
            return existingAlbum;
        }

        
        public async Task<bool> DeleteAlbumByIdAsync(int id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return false;
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


