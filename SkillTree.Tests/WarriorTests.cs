using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillTree.Roles;

namespace SkillTree.Tests
{
    [TestClass]
    public class WarriorTests
    {
        [TestMethod]
        public void WarriorShouldContainsOwnSkillSetTest()
        {
            var warrior = new Warrior();

            Assert.IsNotNull(warrior.Skills[Warrior.SkillTypes.Strike], "Strike");
            Assert.IsNotNull(warrior.Skills[Warrior.SkillTypes.Hit], "Hit");
            Assert.IsNotNull(warrior.Skills[Warrior.SkillTypes.DoubleStrike], "Double Strike");
            Assert.IsNotNull(warrior.Skills[Warrior.SkillTypes.Slash], "Slash");
            Assert.IsNotNull(warrior.Skills[Warrior.SkillTypes.Knockout], "Knockout");
            Assert.IsNotNull(warrior.Skills[Warrior.SkillTypes.RoundhouseKick], "Roundhouse Kick");
        }

        [TestMethod]
        public void WarriorStrikeSkillShouldContainsDoubleStrikeAndSlashSkillsTest()
        {
            var warrior = new Warrior();

            var strike = warrior.Skills[Warrior.SkillTypes.Strike];

            Assert.AreEqual(2, strike.Childern.Length);
            Assert.IsTrue(strike.Childern.Any(x => x == warrior.Skills[Warrior.SkillTypes.DoubleStrike]));
            Assert.IsTrue(strike.Childern.Any(x => x == warrior.Skills[Warrior.SkillTypes.Slash]));
        }

        [TestMethod]
        public void WarriorRoundhouseKickShouldHasSlashAndKnokoutParentsSkillsTest()
        {
            var warrior = new Warrior();

            var strike = warrior.Skills[Warrior.SkillTypes.RoundhouseKick];

            Assert.AreEqual(2, strike.Parents.Length);
            Assert.IsTrue(strike.Parents.Any(x => x == warrior.Skills[Warrior.SkillTypes.Knockout]));
            Assert.IsTrue(strike.Parents.Any(x => x == warrior.Skills[Warrior.SkillTypes.Slash]));
        }
    }
}
