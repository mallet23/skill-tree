using System;
using System.Linq;

namespace SkillTree.Skills
{
    public class Skill
    {
        public string Name { get; }
        public bool IsLocked { get; private set; }
        public bool CanBeUnlockedLocked => Parents?.All(x => !x.IsLocked) ?? true;
        public Skill[] Childern { get; }
        public Skill[] Parents { get; private set; }

        public Skill(string name, Skill[] children = null)
        {
            IsLocked = true;
            Name = name;
            Parents = Array.Empty<Skill>();

            Childern = children ?? Array.Empty<Skill>();
            foreach (var child in Childern)
            {
                child.Parents = child.Parents.Concat(new[] { this }).ToArray();
            }
        }

        public bool TryUnlock()
        {
            if (!CanBeUnlockedLocked)
            {
                return false;
            }

            IsLocked = false;
            return true;
        }
    }
}
