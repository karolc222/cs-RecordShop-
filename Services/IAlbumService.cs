using RecordShop.Models;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
        List<Album> GetAll();
        Album GetById(int id);
        void Add(Album album);
        void Delete(int id);
        void Update(int id, Album album);
    }
}