using KnightSequences.Library.Interfaces;

namespace KnightSequences.Library
{
    public class Walker : IWalker
    {
        private long _walkCount;
        private int _vowelCount;
        private int _depth;
        private readonly int _maxDepth;
        private readonly int _maxVowels;

        public Walker(int maxDepth, int maxVowels)
        {
            _maxDepth = maxDepth;
            _maxVowels = maxVowels;
        }

        public long Walk(IKey key)
        {
            _depth++;
            _vowelCount += key.Vowel;

            foreach (var nextKey in key.ValidMoves)
            {
                if (IsMaxVowels(nextKey.Vowel)) continue;
                if (IsMaxDepth())
                {
                    _walkCount++;
                    continue;
                }

                Walk(nextKey);
            }
            _vowelCount -= key.Vowel;
            _depth--;
            return _walkCount;
        }

        private bool IsMaxDepth()
        {
            return _depth + 1 == _maxDepth;
        }

        private bool IsMaxVowels(int leafVowel)
        {
            return leafVowel + _vowelCount > _maxVowels;
        }
    }
}
