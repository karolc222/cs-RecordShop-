using RecordShop.Models;
using RecordShop.Repositories;

namespace RecordShop.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;

        //constructor for dependency injection
        public AlbumService(IAlbumRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<Album>> GetAllAlbumsAsync()
        {
            return await _repository.GetAllAlbumsAsync();
        }

        public async Task<Album?> GetAlbumByIdAsync(int id)
        {
            return await _repository.GetAlbumByIdAsync(id);
        }

        //the service receives the album and passes it to the repository
        public async Task<Album> PostAlbumAsync(Album album)
        {
            return await _repository.PostAlbumAsync(album);
        }
        

        public async Task<Album?> PutAlbumAsync(int id, Album album)
        {
            return await _repository.PutAlbumAsync(id, album);
        }

        public async Task<bool> DeleteAlbumByIdAsync(int id)
        {
            return await _repository.DeleteAlbumByIdAsync(id);
        }

        
    }
}