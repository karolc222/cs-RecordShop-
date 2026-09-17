//handles all database access 
using Microsoft.EntityFrameworkCore;
using RecordShop.Data;
using RecordShop.Models;

namespace RecordShop.Repositories
{
    public class AlbumRepository 
    {
        //storing db connection inside the class 
        // _context means private field, only this class can use it 
        private readonly AppDbContext _context;

        //dependancy injection 
        //context constructor
        public AlbumRepository(AppDbContext context)
        {
            _context = context;
        }

        //list all albums in stock 
        public List<Album> GetAll()
        {
            return _context.Albums.ToList();
        }

        // get album by id 
        public Album GetById(int id)
        {
            return _context.Albums.Find(id);
        }

        // add new albums 
        public void Add(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var album = _context.Albums.Find(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
        }

        public void Update(int id, Album updatedAlbum)
        {
            var existingAlbum = _context.Albums.Find(id);

            if (existingAlbum != null)
            {
                existingAlbum.AlbumTitle = updatedAlbum.AlbumTitle;
                existingAlbum.Artist = updatedAlbum.Artist;
                existingAlbum.ReleaseDate = updatedAlbum.ReleaseDate;

                _context.SaveChanges();
            }
        }
    }
}


