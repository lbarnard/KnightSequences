using KnightSequences.Library.Interfaces;

namespace KnightSequences.Library
{
    public class WalkerFactory : IWalkerFactory
    {
        public IWalker Create(int maxDepth, int maxVowels)
        {
            return new Walker(maxDepth, maxVowels);
        }
    }
}
