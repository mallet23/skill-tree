using System.Collections.Generic;
using SkillTree.Skills;

namespace SkillTree.Roles
{
    public abstract class Character<TSkill> : IRole
    {
        public abstract string Name { get; }
        public SkillGraph<TSkill> Skills { get; }

        protected abstract Dictionary<TSkill, string> SkillsNames { get; }

        protected Character()
        {
            Skills = new SkillGraph<TSkill>();
            CreateSkillSet();
        }

        protected abstract void CreateSkillSet();

        protected Skill AddSkill(TSkill skill, Skill[] parents = null)
        {
            return Skills.Add(skill, SkillsNames[skill], parents);
        }
    }
}
