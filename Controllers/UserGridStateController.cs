using GridStatePOC.Data;
using GridStatePOC.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GridStatePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserGridStateController : ControllerBase
    {
        private readonly ILogger<UserGridStateController> _logger;
        private readonly ApplicationDbContext _db;

        public UserGridStateController(ILogger<UserGridStateController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SaveRequestDto req)
        {
            if (string.IsNullOrEmpty(req.PageKey))
                return BadRequest("Missing PageKey");

            var userName = User.Identity?.Name ?? "Unknown";

            var existing = await _db.GridStates
                .FirstOrDefaultAsync(x => x.UserName == userName && x.PageKey == req.PageKey);

            if (existing == null)
            {
                _db.GridStates.Add(new GridState
                {
                    UserName = userName,
                    PageKey = req.PageKey,
                    StateJson = req.StateJson,
                    UpdatedAt = DateTime.UtcNow
                });
            }
            else
            {
                existing.StateJson = req.StateJson;
                existing.UpdatedAt = DateTime.UtcNow;
            }

            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] string pageKey)
        {
            var userName = User.Identity?.Name ?? "Unknown";

            var state = await _db.GridStates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName == userName && x.PageKey == pageKey);

            return Ok(new { state?.StateJson });
        }
    }
}
