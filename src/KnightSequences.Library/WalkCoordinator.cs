using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KnightSequences.Library.Interfaces;

namespace KnightSequences.Library
{
    public class WalkCoordinator : IWalkCoordinator
    {
        private long _walkCount;
        public int MaxDepth;
        private readonly IKeyPad _keypad;
        private readonly IWalkerFactory _factory;

        public WalkCoordinator(IKeyPad keypad, IWalkerFactory factory)
        {
            _keypad = keypad;
            _factory = factory;
        }

        public long Walk(int maxDepth, int maxVowels)
        {
            var keys = _keypad.Keys.Where(x => x.Value != null);
            Parallel.ForEach(keys, key =>
                                        {
                                            var walker = _factory.Create(maxDepth, maxVowels);
                                            Interlocked.Add(ref _walkCount, walker.Walk(key));
                                        });
            return _walkCount;
        }

    }
}
