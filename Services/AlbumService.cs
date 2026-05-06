using RecordShop.Models;
using RecordShop.Repositories;

namespace RecordShop.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly AlbumRepository _repository;

        public AlbumService(AlbumRepository repository)
        {
            _repository = repository;
        }

        public List<Album> GetAll()
        {
            return _repository.GetAll();
        }

        public Album GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Album album)
        {
            _repository.Add(album);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(int id, Album album)
        {
            _repository.Update(id, album);
        }
    }
}