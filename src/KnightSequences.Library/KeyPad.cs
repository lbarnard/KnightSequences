using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using KnightSequences.Library.Interfaces;

namespace KnightSequences.Library
{
    public class KeyPad : IKeyPad
    {
        public List<IKey> Keys { get; set; }

        public KeyPad(IList<string[]> keypad)
        {
            Keys = new List<IKey>();

            for (var y = 0; y < keypad.Count; y++)
            {
                for (var x = 0; x < keypad[y].Length; x++)
                {
                    if (keypad[y][x] == null) continue;

                    var key = keypad[y][x];
                    var validMoves = new List<IKey>();

                    AddKnightMove(x, y, 2, 1, keypad, validMoves);
                    AddKnightMove(x, y, 1, 2, keypad, validMoves);
                    AddKnightMove(x, y, -1, 2, keypad, validMoves);
                    AddKnightMove(x, y, -2, 1, keypad, validMoves);
                    AddKnightMove(x, y, -2, -1, keypad, validMoves);
                    AddKnightMove(x, y, -1, -2, keypad, validMoves);
                    AddKnightMove(x, y, 1, -2, keypad, validMoves);
                    AddKnightMove(x, y, 2, -1, keypad, validMoves);

                    Keys.Add(new Key {Value = key, Vowel = Regex.IsMatch(key, "[AEIOU]") ? 1 : 0, ValidMoves = validMoves});
                }
            }

            foreach (Key key in Keys)
            {
                foreach (Key nextKey in key.ValidMoves)
                {
                    nextKey.ValidMoves.AddRange(Keys.First(x => x.Value == nextKey.Value).ValidMoves);
                }
            }
        }   

        private static void AddKnightMove(int x, int y, int dX, int dY, IList<string[]> keypad, ICollection<IKey> validMoves)
        {
            if (y + dY < keypad.Count 
                && x + dX < keypad[y].Length 
                && y + dY > -1 
                && x + dX > -1)
            {
                var validMove = keypad[y + dY][x + dX];
                if (validMove != null)
                    validMoves.Add(new Key {Value = validMove, Vowel = Regex.IsMatch(validMove, "[AEIOU]") ? 1 : 0, ValidMoves = new List<IKey>()});
            }
        }
    }
}
