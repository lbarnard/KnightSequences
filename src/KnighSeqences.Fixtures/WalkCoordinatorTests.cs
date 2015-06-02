using System.Collections.Generic;
using KnightSequences.Library;
using KnightSequences.Library.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace KnightSeqences.Fixtures
{
    [TestFixture]
    public class WalkCoordinatorTests
    {
        private IKeyPad _keyPad;
        private IWalkerFactory _factory ;
        private IWalker _walker;

        [SetUp]
        public void SetUp()
        {
            _keyPad = MockRepository.GenerateStrictMock<IKeyPad>();
            _factory = MockRepository.GenerateStrictMock<IWalkerFactory>();
            _walker = MockRepository.GenerateStrictMock<IWalker>();
        }

        [TearDown]
        public void TearDown()
        {
            _keyPad.VerifyAllExpectations();
            _factory.VerifyAllExpectations();
            _walker.VerifyAllExpectations();
        }

        [Test]
        public void KeyPadWithNoKeysReturnsZero()
        {
            const int expected = 0;
            IWalkCoordinator walkCoordinator = new WalkCoordinator(_keyPad, _factory);

            _keyPad.Expect(x => x.Keys).Return(new List<IKey>());

            var result = walkCoordinator.Walk(10, 2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void KeyPadWithOneKeysReturnsZero()
        {
            const int expected = 0;
            IWalkCoordinator walkCoordinator = new WalkCoordinator(_keyPad, _factory);
            _factory.Expect(x => x.Create(10, 2));
            _keyPad.Expect(x => x.Keys).Return(new List<IKey>{ new Key {Value="B", Vowel= 0, ValidMoves = new List<IKey>()}});

            var result = walkCoordinator.Walk(10, 2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void KeyPadWithTwoKeysReturns1()
        {
            const int expected = 1;
            IWalkCoordinator walkCoordinator = new WalkCoordinator(_keyPad, _factory);

            Key zKey = new Key { Value = "Z", Vowel = 0, ValidMoves = new List<IKey>() };
            Key bKey = new Key { Value = "B", Vowel = 0, ValidMoves = new List<IKey>() };
            zKey.ValidMoves.Add(bKey);
            bKey.ValidMoves.Add(zKey);

            _factory.Expect(x => x.Create(10, 2)).Return(_walker);
            _walker.Expect(x => x.Walk(zKey)).Return(1);
            _keyPad.Expect(x => x.Keys).Return(new List<IKey> {zKey});

            var result = walkCoordinator.Walk(10, 2);
            Assert.AreEqual(expected, result);
        }


    }
}