using GridStatePOC.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GridStatePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly ApplicationDbContext _db;

        public CitiesController(ILogger<CitiesController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var data = await _db.Cities.AsNoTracking().ToListAsync();
            return Ok(data);
        }
    }
}
