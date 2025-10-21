using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSync.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Role { get; private set; } // Developer or Recruiter
        public List<Skill> Skills { get; private set; } = new();

        public User(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public void AddSkill(Skill skill)
        {
            if (!Skills.Any(s => s.Name == skill.Name))
                Skills.Add(skill);
        }
    }
}
