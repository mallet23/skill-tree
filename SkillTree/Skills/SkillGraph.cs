using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillTree.Skills
{
    public class SkillGraph<TKey>
    {
        private readonly Dictionary<TKey, Skill> _skills = new Dictionary<TKey, Skill>();

        public Skill[] RootSkills
        {
            get
            {
                return _skills.Where(x => x.Value.Parents == null).Select(x => x.Value).ToArray();
            }
        }

        public Skill Add(TKey key, string name, Skill[] children = null)
        {
            if (_skills.ContainsKey(key))
                throw new Exception($"Skill `{name}` has been already created!");

            return _skills[key] = new Skill(name, children);
        }

        public Skill this[TKey key]
        {
            get
            {
                _skills.TryGetValue(key, out var skill);
                return skill;
            }
        }

        public int Count => _skills.Count;
    }
}
