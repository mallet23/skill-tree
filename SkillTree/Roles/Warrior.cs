using System.Collections.Generic;

namespace SkillTree.Roles
{
    public class Warrior : Character<Warrior.SkillTypes>
    {
        public enum SkillTypes
        {
            Strike,
            Hit,
            DoubleStrike,
            Slash,
            Knockout,
            RoundhouseKick
        }

        protected override Dictionary<SkillTypes, string> SkillsNames => new Dictionary<SkillTypes, string>
        {
            {SkillTypes.Hit, "Hit"},
            {SkillTypes.Strike, "Strike"},
            {SkillTypes.DoubleStrike, "Double Strike"},
            {SkillTypes.Slash, "Slash"},
            {SkillTypes.Knockout, "Knockout"},
            {SkillTypes.RoundhouseKick, "Roundhouse Kick"},
        };

        public override string Name => "Warrior";

        protected override void CreateSkillSet()
        {
            var roundhouseKick = AddSkill(SkillTypes.RoundhouseKick);
            var doubleStrike = AddSkill(SkillTypes.DoubleStrike);
            var slash = AddSkill(SkillTypes.Slash, new[] { roundhouseKick });
            var knockout = AddSkill(SkillTypes.Knockout, new[] { roundhouseKick });
            var strike = AddSkill(SkillTypes.Strike, new[] { doubleStrike, slash });
            var hit = AddSkill(SkillTypes.Hit, new[] { knockout });
        }
    }
}