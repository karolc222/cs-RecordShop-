using RecordShop.Models;

namespace RecordShop.Repositories
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAllAlbumsAsync();
        Task<Album?> GetAlbumByIdAsync(int id);
        Task<Album> PostAlbumAsync(Album postedAlbum);
        Task<Album?> PutAlbumAsync(int id, Album updatedAlbum);
        Task<bool> DeleteAlbumByIdAsync(int id);
    }
}