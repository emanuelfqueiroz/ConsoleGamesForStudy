using System;
using System.Collections.Generic;
using System.Text;

namespace HangManGame
{

    internal class WorkFlow
    {

        public Game Game { get; set; }

        public WorkFlow()
        {

        }
        public WorkFlow(Game game)
        {
            Game = game;
        }
        public void Start(Settings settings)
        {
            if (Game == null || Game.Status != StatusEnum.Running)
            {
                Game = new Game(GetRandomWord(settings), settings);
            }
        }
        protected Word GetRandomWord(Settings settings)
        {
            int randomIndex = new Random().Next(0, settings.Words.Length);
            string selectedWord = settings.Words[randomIndex];
            return new Word(selectedWord, settings.SecretChar);
        }
        public void Stop()
        {
            Game.Status = StatusEnum.Over;
        }


    }
}
