using System.Linq;
using KnightSequences.Library;
using KnightSequences.Library.Interfaces;
using NUnit.Framework;

namespace KnightSeqences.Fixtures
{
    [TestFixture]
    public class KeyPadTests
    {
        private string[][] _keypadArray;
        [SetUp]
        public void SetUp()
        {
            _keypadArray = KeyPadHelper.Build();
        }

        [Test]
        public void TreeStructureIsValid()
        {
            IKeyPad keyPad = new KeyPad(_keypadArray);
            Assert.IsNotNull(keyPad);
            Assert.AreEqual(18, keyPad.Keys.Count(x => x.Value != null));
        }

        [Test]
        public void TreeStructureChildrenAreValidKnightMoves()
        {
            IKeyPad keyPad = new KeyPad(_keypadArray);
            Assert.That(keyPad.Keys.First(x => x.Value == "A").ValidMoves.First(y => y.Value == "L") != null);
            Assert.That(keyPad.Keys.First(x => x.Value == "L").ValidMoves.First(y => y.Value == "A" && y.Vowel == 1) != null);
            Assert.That(keyPad.Keys.First(x => x.Value == "L").ValidMoves.First(y => y.Value == "3" && y.Vowel == 0) != null);
            Assert.That(keyPad.Keys.First(x => x.Value == "1").ValidMoves.First(y => y.Value == "H") != null);
        }
    }
}