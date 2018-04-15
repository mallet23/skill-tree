namespace SkillTree
{
    public class Role
    {
        public string Name { get; }
        public Skill[] Skills { get; }

        public Role(string name, Skill[] skills)
        {
            Name = name;
            Skills = skills;
        }
    }
}
