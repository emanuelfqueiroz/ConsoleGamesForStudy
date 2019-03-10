using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HangManGame
{

    public class Word
    {
        public string Secret { get; private set; }
        public List<char> Revealed { get; private set; }
        public char SecretChar { get; private set; }

        public Word(string secret, char secretChar)
        {
            Secret = secret;
            this.SecretChar = secretChar;
            BuildRevealed();
        }

        private void BuildRevealed()
        {
            Revealed = new List<char>(Secret.Length);
            for (int i = 0; i < Secret.Length; i++)
            {
                Revealed.Add(this.SecretChar);
            }
        }
        internal bool Contains(char c)
        {
            return Secret.Contains(c);
        }
        internal bool IsReveleadCharacter(char c)
        {
            return Revealed.Contains(c);
        }

        public void RevealChar(char c)
        {
            for (int i = 0; i < Secret.Length; i++)
            {
                if (Secret[i].Equals(c))
                {
                    Revealed[i] = c;
                }
            }
        }
        public bool IsSolved => Revealed.ToArray().Count(p => !p.Equals(SecretChar)) == Secret.Length;
    }
}
