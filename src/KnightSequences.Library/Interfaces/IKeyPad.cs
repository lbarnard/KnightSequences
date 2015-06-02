using System.Collections.Generic;

namespace KnightSequences.Library.Interfaces
{
    public interface IKeyPad
    {
        List<IKey> Keys { get; set; }
    }
}