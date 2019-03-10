using System;
using System.Collections.Generic;

namespace Tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Game
    {
        public List<Player> Players { get; set; }
        public StatusEnum Status { get; set; }
        public Game()
        {
            Players = new List<Player>();
            Status = StatusEnum.Over;
        }
        
        public static Game Create(string play1, string play2)
        {
            var game = new Game();
            game.Players.Add(new Player(play1));
            game.Players.Add(new Player(play2));
            game.Status = StatusEnum.Over;
            return game;
        }

    }
}
