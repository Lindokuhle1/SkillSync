using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Application.Services;

namespace SkillSync.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        private readonly MatchService _service;

        public MatchController(MatchService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMatches(Guid userId)
        {
            var matches = await _service.GetMatchesForUser(userId);
            return Ok(matches);
        }
    }
}
