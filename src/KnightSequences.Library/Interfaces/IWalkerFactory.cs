namespace KnightSequences.Library.Interfaces
{
    public interface IWalkerFactory
    {
        IWalker Create(int maxDepth, int maxVowels);
    }
}