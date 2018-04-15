using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillTree.Skills;

namespace SkillTree.Tests
{
    [TestClass]
    public class SkillGraphTests
    {
        [TestMethod]
        public void ShouldAddNewSkillTest()
        {
            var graph = new SkillGraph<int>();
            var name = "skill";
            var key = 1;

            graph.Add(key, name);

            Assert.IsNotNull(graph[key]);
            Assert.AreEqual(name, graph[key].Name);
        }

        [TestMethod]
        public void ShouldAddChildElementsWhenSkillHasChildrenTest()
        {
            var graph = new SkillGraph<int>();
            var child = graph.Add(2, "child skill");
            var parent = graph.Add(10, "parent skill", new[] { child });

            Assert.IsNotNull(parent.Childern);
            Assert.AreEqual(1, parent.Childern.Length);
            Assert.IsNotNull(child.Parents);
            Assert.AreEqual(1, child.Parents.Length);
        }

        [TestMethod]
        public void ChildSkillShouldBeLockedWhenItHasLockedParentSkillTest()
        {
            var graph = new SkillGraph<int>();
            var child = graph.Add(2, "child skill");
            var parent = graph.Add(10, "parent skill", new[] { child });

            Assert.IsTrue(parent.IsLocked);
            Assert.IsTrue(parent.CanBeUnlockedLocked);
            Assert.IsFalse(child.CanBeUnlockedLocked);
            Assert.IsTrue(child.IsLocked);
        }

        [TestMethod]
        public void ChildSkillCanNotBeUnlockedLockedWhenItHasLockedParentSkillTest()
        {
            var graph = new SkillGraph<int>();
            var child = graph.Add(2, "child skill");
            var parent = graph.Add(10, "parent skill", new[] { child });

            Assert.IsTrue(parent.IsLocked);
            Assert.IsFalse(child.CanBeUnlockedLocked);
            Assert.IsFalse(child.TryUnlock());
        }

        [TestMethod]
        public void ChildSkillCanBeUnlockedLockedWhenItHasUnlockedLockedParentSkillTest()
        {
            var graph = new SkillGraph<int>();
            var child = graph.Add(2, "child skill");
            var parent = graph.Add(10, "parent skill", new[] { child });

            parent.TryUnlock();

            Assert.IsFalse(parent.IsLocked);
            Assert.IsTrue(parent.CanBeUnlockedLocked);
            Assert.IsTrue(child.CanBeUnlockedLocked);
            Assert.IsTrue(child.IsLocked);
        }

        [TestMethod]
        public void ChildSkillCanNotBeUnlockedLockedWhenOneOfTheParentsIsLockedTest()
        {
            var graph = new SkillGraph<int>();
            var child = graph.Add(2, "child skill");
            var parent1 = graph.Add(10, "parent 1 skill", new[] { child });
            var parent2 = graph.Add(20, "parent 2 skill", new[] { child });

            parent1.TryUnlock();

            Assert.IsFalse(parent1.IsLocked);
            Assert.IsTrue(parent2.IsLocked);
            Assert.IsFalse(child.CanBeUnlockedLocked);
            Assert.IsFalse(child.TryUnlock());
        }

    }
}
