using System.Linq;

namespace SkillTree
{
    public class Skill
    {
        public string Name { get; }
        public bool IsLocked { get; private set; }
        public bool CanBeUnlockedLocked => Parents.All(x => !x.IsLocked);
        public Skill[] Childern { get; set; }
        public Skill[] Parents { get; set; }

        public Skill(string name)
        {
            Name = name;
        }

        public bool TryUnlock()
        {
            if (CanBeUnlockedLocked)
            {
                return false;
            }

            IsLocked = false;
            return true;
        }
    }
}
