using RecordShop.Models;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAllAlbumsAsync();
        Task<Album?> GetAlbumByIdAsync(int id);
        Task <Album> PostAlbumAsync(Album album);
        Task<Album?> PutAlbumAsync(int id, Album album);
        Task<bool> DeleteAlbumByIdAsync(int id);
    }
}