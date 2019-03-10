using System;
using System.Collections.Generic;
using System.Text;

namespace HangManGame
{

    public class Game
    {
        public StatusEnum Status { get; set; }

        public Guid Id { get; set; }
        public Word Word { get; set;  }
        public GameAttempts Tries { get; }
        public Settings Settings { get; set; }

        public Game(Word word, Settings settings)
        {
            Id = Guid.NewGuid();
            Settings = settings;
            Word = word;
            Tries = new GameAttempts(settings.MaxTries);
            Status = StatusEnum.Running;
        }

        public void Try(string attempt)
        {
            if (attempt.Length != 1)
            {
                throw new ArgumentException("Pease, just one character.");
            }

            char c = attempt.ToLower()[0];

            if (Word.Contains(c))
            {
                if (Word.IsReveleadCharacter(c))
                {
                    if (Settings.IsRepeatedAttemptWrong)
                    {
                        Tries.Add(c, WasSuccess: false);
                    }
                }
                else
                {
                    Word.RevealChar(c);
                    Tries.Add(c, WasSuccess: true);
                }
            }
            else
            {
                Tries.Add(c, WasSuccess: false);
            }

            CheckGameStatus();
        }

        private void CheckGameStatus()
        {
            if (Word.IsSolved)
            {
                Status = StatusEnum.Success;
            }
            else if (Tries.RemainingTries == 0)
            {
                Status = StatusEnum.Over;
            }
        }
    }
}
