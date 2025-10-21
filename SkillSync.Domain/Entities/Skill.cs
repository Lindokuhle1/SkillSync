using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSync.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int ProficiencyLevel { get; set; } // 1–10 scale
        public DateTime LastPracticed { get; set; } = DateTime.UtcNow;
    }
}
