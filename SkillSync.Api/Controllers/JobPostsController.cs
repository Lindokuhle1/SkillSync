using Microsoft.AspNetCore.Mvc;
using SkillSync.Application.DTOs;
using SkillSync.Application.Interfaces;
using SkillSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSync.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostsController : ControllerBase
    {
        private readonly IRepository<JobPost> _jobRepo;
        private readonly IRepository<Skill> _skillRepo;

        public JobPostsController(IRepository<JobPost> jobRepo, IRepository<Skill> skillRepo)
        {
            _jobRepo = jobRepo;
            _skillRepo = skillRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobPostDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var job = new JobPost(dto.Title, dto.Description);

            // Add required skills (existing or new)
            foreach (var skillName in dto.RequiredSkills.Distinct())
            {
                // Try find existing skill
                var skill = (await _skillRepo.GetAllAsync()).FirstOrDefault(s => s.Name == skillName);
                if (skill == null)
                {
                    skill = new Skill { Name = skillName };
                    await _skillRepo.AddAsync(skill);
                }

                job.AddRequiredSkill(skill);
            }

            await _jobRepo.AddAsync(job);

            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _jobRepo.GetAllAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var job = await _jobRepo.GetByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }
    }
}
