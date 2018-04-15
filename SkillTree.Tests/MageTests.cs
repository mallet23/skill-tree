using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillTree.Roles;

namespace SkillTree.Tests
{
    [TestClass]
    public class MageTests
    {
        [TestMethod]
        public void MageShouldContainsOwnSkillSetTest()
        {
            var warrior = new Mage();

            Assert.IsNotNull(warrior.Skills[Mage.SkillTypes.Electroshock], "Electroshock");
            Assert.IsNotNull(warrior.Skills[Mage.SkillTypes.Fireball], "Fireball");
            Assert.IsNotNull(warrior.Skills[Mage.SkillTypes.Freeze], "Freeze");
            Assert.IsNotNull(warrior.Skills[Mage.SkillTypes.Snowstorm], "Snowstorm");
            Assert.IsNotNull(warrior.Skills[Mage.SkillTypes.Thunderbolt], "Thunderbolt");
        }
    }
}
