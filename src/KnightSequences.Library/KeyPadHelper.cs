using System.Collections.Generic;

namespace KnightSeqences.Fixtures
{
    public static class KeyPadHelper
    {
        public static string[][] Build()
        {
            var keypadList = new List<string[]>
                                 {
                                     new[] {"A", "B", "C", "D", "E"},
                                     new[] {"F", "G", "H", "I", "J"},
                                     new[] {"K", "L", "M", "N", "O"},
                                     new[] {null, "1", "2", "3", null}
                                 };

            return keypadList.ToArray();
        }
    }
}
