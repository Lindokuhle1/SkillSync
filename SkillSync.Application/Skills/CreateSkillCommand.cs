using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSync.Application.Skills
{
    public record CreateSkillCommand(string Name, int ProficiencyLevel) : IRequest<Guid>;
}
