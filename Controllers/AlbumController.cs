using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;
using RecordShop.Models;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _service;

        public AlbumController(IAlbumService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbumsAsync()
        {
            var albums = await _service.GetAllAlbumsAsync();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(int id) 
        {
            var album = await _service.GetAlbumByIdAsync(id);

            if (album == null)
                return NotFound();

            return Ok(album);
        }

        [HttpPost]
        public async Task<IActionResult> PostAlbumAsync(Album album)
        {
            var createdAlbum = await _service.PostAlbumAsync(album);
            return CreatedAtAction(nameof(GetAlbumByIdAsync), new { id = createdAlbum.AlbumId }, createdAlbum);        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumByIdAsync(int id)
        {
            var deleted = await _service.DeleteAlbumByIdAsync(id);

            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbumAsync(int id, Album updatedAlbum)
        {
            var updated = await _service.PutAlbumAsync(id, updatedAlbum);

            if (updated == null)
                return NotFound();

            return Ok(updated); 
        }
    }
}