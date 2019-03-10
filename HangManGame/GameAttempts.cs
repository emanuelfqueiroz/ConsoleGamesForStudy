using System;
using System.Collections.Generic;
using System.Text;

namespace HangManGame
{

    public class GameAttempts
    {
        public int InitialTries { get; set; }
        public int WrongTries { get; private set; }
        public  List<char> Chars { get; private set; } = new List<char>();
        public int RemainingTries => InitialTries - WrongTries;

        public GameAttempts(int initialTries)
        {
            InitialTries = initialTries;
            WrongTries = 0;
        }

        public void Add(char c, bool WasSuccess)
        {
            Chars.Add(c);
            if (!WasSuccess)
            {
                WrongTries++;
            }
        }
    }
}
