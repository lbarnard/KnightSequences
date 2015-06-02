using KnightSequences.Library;
using NUnit.Framework;

namespace KnightSeqences.Fixtures
{
    [TestFixture]
    public class WalkerFactoryTests
    {
        [Test]
        public void TestConstruction()
        {
            var factory = new WalkerFactory();
            var actual = factory.Create(10, 2);
            Assert.That(actual != null);
        }
    }
}