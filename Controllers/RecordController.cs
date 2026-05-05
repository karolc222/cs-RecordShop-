using Microsoft.AspNetCore.Mvc;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRecords()
        {
            return Ok(new string[] { "Record 1", "Record 2" });
        }
    }
}