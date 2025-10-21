using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Application.Interfaces;
using SkillSync.Domain.Entities;

namespace SkillSync.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repo;

        public UsersController(IRepository<User> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            var user = new User(name, "Developer");
            await _repo.AddAsync(user);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repo.GetAllAsync();
            return Ok(users);
        }
    }
}
