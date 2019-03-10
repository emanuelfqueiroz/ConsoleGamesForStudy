using System;
using System.Collections.Generic;
using System.Text;

namespace HangManGame
{
    internal class GameUIConsole
    {
        private readonly string stopGameCommand = "stop";
        public WorkFlow WorkFlow { get; set; }


        internal void Run()
        {
            do
            {
                NewGame();
            } while (AskToContinue());
        }

        private void NewGame()
        {
            WorkFlow = new WorkFlow();
            WorkFlow.Start(CreateSettings());
            Console.Clear();
            Console.WriteLine("Started a new game. Press any key to start");
            Console.ReadLine();

            string text = "";
            Game game = WorkFlow.Game;

            do
            {
                RenderGame(game);
                try
                {
                    Console.WriteLine($"Next Letter or {this.stopGameCommand} to stop game");
                    text = Console.ReadLine();
                    if (text.Equals(stopGameCommand))
                    {
                        WorkFlow.Stop();
                        break;
                    }
                    game.Try(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }

            }
            while (WorkFlow.Game.Status == StatusEnum.Running);
            RenderFinalResultOnGame(WorkFlow.Game);
        }


        private bool AskToContinue()
        {
            Console.WriteLine("Would you like restart? S/N");
            string line = Console.ReadLine();
            return line.Equals("s", StringComparison.InvariantCulture);
        }


        private void RenderGame(Game game)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("Word: " + RevealedWord);
            Console.WriteLine("");
            Console.WriteLine("Remaining Tries: " + game.Tries.RemainingTries);
            Console.WriteLine("All Tries: " + string.Join(" , ", game.Tries.Chars));

        }
        private Settings CreateSettings()
        {
            Settings Spec = new Settings
            {
                SecretChar = '_'
            };
            return Spec;
        }

        private void RenderFinalResultOnGame(Game game)
        {
            RenderGame(game);
            if (WorkFlow.Game.Status == StatusEnum.Success)
            {
                Console.WriteLine("Congratulation!");
                Console.ReadLine();
                WorkFlow.Game = null;
            }
            else if (WorkFlow.Game.Status == StatusEnum.Over)
            {
                Console.WriteLine("Game Over!");
                Console.WriteLine("the word was : " + WorkFlow.Game.Word.Secret);
                Console.ReadLine();
                WorkFlow.Game = null;
            }
            else
            {
                Console.WriteLine("Undefined Status. What happened?");
                Console.ReadLine();
                WorkFlow.Game = null;
            }
        }

        public string RevealedWord
        {
            get
            {
                string margin = " ";
                string str = "";
                WorkFlow.Game.Word.Revealed.ForEach(p => str += margin + p.ToString());
                return str;
            }
        }

    }
}
