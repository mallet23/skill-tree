using System.Collections.Generic;

namespace SkillTree.Roles
{
    public class Mage : Character<Mage.SkillTypes>
    {
        public enum SkillTypes
        {
            Snowstorm,
            Thunderbolt,
            Electroshock,
            Freeze,
            Fireball,
        }

        public override string Name => "Mage";

        protected override Dictionary<SkillTypes, string> SkillsNames => new Dictionary<SkillTypes, string>
        {
            { SkillTypes.Snowstorm, "Snowstorm" },
            { SkillTypes.Thunderbolt, "Thunderbolt" },
            { SkillTypes.Electroshock, "Electroshock" },
            { SkillTypes.Freeze, "Freeze" },
            { SkillTypes.Fireball, "Fireball" },
        };

        protected override void CreateSkillSet()
        {
            var snowstorm = AddSkill(SkillTypes.Snowstorm);
            var thunderbolt = AddSkill(SkillTypes.Thunderbolt);
            var electroshock = AddSkill(SkillTypes.Electroshock, new[] { thunderbolt });
            var freeze = AddSkill(SkillTypes.Freeze, new[] { snowstorm });
            var fireball = AddSkill(SkillTypes.Fireball, new[] { electroshock, freeze });
        }
    }
}
