using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillSync.Domain.Entities
{
    public class JobPost
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Skill> RequiredSkills { get; set; } = new();

        public JobPost() { } // EF Core needs parameterless constructor

        public JobPost(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void AddRequiredSkill(Skill skill)
        {
            if (!RequiredSkills.Any(s => s.Name == skill.Name))
                RequiredSkills.Add(skill);
        }
    }
}
