using System.Collections.Generic;
using KnightSequences.Library;
using KnightSequences.Library.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace KnightSeqences.Fixtures
{
    [TestFixture]
    public class WalkerTests
    {
        private IKey _key;

        [SetUp]
        public void SetUp()
        {
            _key = MockRepository.GenerateStrictMock<IKey>();
        }

        [TearDown]
        public void TearDown()
        {
            _key.VerifyAllExpectations();
        }

        [Test]
        public void KeyPadWithSingleKeyReturnsZero()
        {
            const int expected = 0;
            IWalker walker = new Walker(10, 2);

            _key.Expect(x => x.Vowel).Return(1).Repeat.Twice();
            _key.Expect(x => x.ValidMoves).Return(new List<IKey>());

            var result = walker.Walk(_key);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void KeyPadWithTwoKeysReturnsOnePath()
        {
            const int expected = 1;
            IWalker walker = new Walker(10, 2);

            Key zKey = new Key {Value = "Z", Vowel = 0, ValidMoves = new List<IKey>()};
            Key bKey = new Key { Value = "B", Vowel = 0, ValidMoves = new List<IKey>() };
            zKey.ValidMoves.Add(bKey);
            bKey.ValidMoves.Add(zKey);

            _key.Expect(x => x.Vowel).Return(0).Repeat.Twice();
            _key.Expect(x => x.ValidMoves).Return(zKey.ValidMoves);

            var result = walker.Walk(_key);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void KeyPadWithTwoKeysAndOneVowelReturnsZeroPaths()
        {
            const int expected = 0;
            IWalker walker = new Walker(10, 2);

            Key aKey = new Key { Value = "A", Vowel = 1, ValidMoves = new List<IKey>() };
            Key bKey = new Key { Value = "B", Vowel = 0, ValidMoves = new List<IKey>() };
            aKey.ValidMoves.Add(bKey);
            bKey.ValidMoves.Add(aKey);

            _key.Expect(x => x.Vowel).Return(0).Repeat.Twice();
            _key.Expect(x => x.ValidMoves).Return(aKey.ValidMoves);

            var result = walker.Walk(_key);
            Assert.AreEqual(expected, result);
        }
    }
}