using System.Collections.Generic;
using KnightSequences.Library.Interfaces;

namespace KnightSequences.Library
{
    public class Key : IKey
    {
        public string Value { get; set; }
        public int Vowel { get; set; }
        public List<IKey> ValidMoves { get; set; }
    }
}