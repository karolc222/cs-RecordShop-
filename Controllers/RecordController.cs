using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;
using RecordShop.Models;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecordController : ControllerBase
    {
        private readonly IAlbumService _service;

        public RecordController(IAlbumService service)
        {
            _service = service; 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var album = _service.GetById(id);

            if (album == null)
                return NotFound();

            return Ok(album);
        }

        [HttpPost]
        public IActionResult Add(Album album)
        {
            _service.Add(album);
            return Created("", album);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Album updatedAlbum)
        {
            var existingAlbum = _service.GetById(id);

            if (existingAlbum == null)
                return NotFound();

            _service.Update(id, updatedAlbum);
            return NoContent();
        }
    }
}