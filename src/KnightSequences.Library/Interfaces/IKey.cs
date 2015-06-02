using System.Collections.Generic;

namespace KnightSequences.Library.Interfaces
{
    public interface IKey
    {
        string Value { get; set; }
        int Vowel { get; set; }
        List<IKey> ValidMoves { get; set; }
    }
}