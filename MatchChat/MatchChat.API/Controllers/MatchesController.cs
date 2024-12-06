using MatchChat.Core.Models.Football;
using MatchChat.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchChat.API.Controllers
{
    // MatchChat.API/Controllers/MatchesController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IFootballApiService _footballApiService;

        public MatchesController(IFootballApiService footballApiService)
        {
            _footballApiService = footballApiService;
        }

        [HttpGet("live")]
        public async Task<ActionResult<IEnumerable<FootballMatch>>> GetLiveMatches()
        {
            try
            {
                var matches = await _footballApiService.GetLiveMatchesAsync();
                return Ok(matches);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<FootballMatch>>> GetUpcomingMatches()
        {
            try
            {
                var matches = await _footballApiService.GetUpcomingMatchesAsync();
                return Ok(matches);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
