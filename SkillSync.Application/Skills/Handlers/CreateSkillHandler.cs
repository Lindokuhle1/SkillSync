using MediatR;
using SkillSync.Application.Common.Interfaces;
using SkillSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSync.Application.Skills.Handlers
{
    public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateSkillHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill
            {
                Name = request.Name,
                ProficiencyLevel = request.ProficiencyLevel,
                LastPracticed = DateTime.UtcNow
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync(cancellationToken);

            return skill.Id;
        }
    }
}
