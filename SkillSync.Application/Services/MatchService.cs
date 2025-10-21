using Microsoft.EntityFrameworkCore;
using SkillSync.Application.Interfaces;
using SkillSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSync.Application.Services
{
    public class MatchService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<JobPost> _jobRepo;

        public MatchService(IRepository<User> userRepo, IRepository<JobPost> jobRepo)
        {
            _userRepo = userRepo;
            _jobRepo = jobRepo;
        }

        public async Task<IEnumerable<(JobPost job, double score)>> GetMatchesForUser(Guid userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            // Ensure Skills are available (if you’re not using EF lazy loading)
            if (user.Skills == null)
                throw new Exception("User skills not loaded");

            var jobs = await _jobRepo.GetAllAsync();

            var userSkills = user.Skills
                .Select(s => s.Name.ToLower().Trim())
                .ToHashSet();

            var matches = jobs.Select(job =>
            {
                var required = job.RequiredSkills?
                    .Select(s => s.Name.ToLower().Trim()) ?? Enumerable.Empty<string>();

                var shared = required.Intersect(userSkills).Count();
                var score = required.Any() ? (double)shared / required.Count() * 100 : 0;

                return (job, score);
            });

            return matches
                .OrderByDescending(m => m.score)
                .ToList();
        }
    }
}
