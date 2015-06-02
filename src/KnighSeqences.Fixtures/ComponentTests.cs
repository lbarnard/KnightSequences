using KnightSequences.Library;
using NUnit.Framework;

namespace KnightSeqences.Fixtures
{
    [TestFixture]
    public class ComponentTests
    {
        [TestCase(10, 2, 1013398)]
        [TestCase(16, 2, 1195650888)]
        //[TestCase(32, 2, ??????????)]
        public void TreeWalkFromKey(int maxDepth, int maxVowels, int expected)
        {
            var keyPad = new KeyPad(KeyPadHelper.Build());
            var walkerFactory = new WalkerFactory();
            var walkCoordinator = new WalkCoordinator(keyPad, walkerFactory);
            var result = walkCoordinator.Walk(maxDepth, maxVowels);
            Assert.AreEqual(expected, result);
        }
    }

}