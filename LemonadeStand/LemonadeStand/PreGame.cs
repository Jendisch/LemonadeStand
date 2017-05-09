using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class PreGame
    {
        public PreGame(Random random)
        {
            this.random = random;
        }

        Random random;
        Game game;

        public void DecideOneOrTwo(Random random)
        {
            UserInterface.WelcomePlayerToGame();
            string choice = UserInterface.AskOneOrTwoPlayers();
            switch (choice)
            {
                case "1":
                    ChooseNewOrOldGame(random);
                    break;
                case "2":
                    game = new Game();
                    game.StartGameTwoPlayers(random);
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    DecideOneOrTwo(random);
                    break;
            }
        }


        public void ChooseNewOrOldGame(Random random)
        {
            string choice = UserInterface.DisplayNewOrLoad();
            switch (choice)
            {
                case "new":
                    game = new Game();
                    game.StartGameOnePlayer(random);
                    break;
                case "load":
                    string name = UserInterface.AskForUniqueName();
                    LoadGame load = new LoadGame();
                    game = load.LoadOldGame(name);
                    if (game == null)
                    {
                        ChooseNewOrOldGame(random);
                    }
                    game.LoadDirectlyToTurn();
                    game.ShowEndingStats();
                    game.AskToPlayAgain(random);
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    ChooseNewOrOldGame(random);
                    break;
            }
             
        }
    }

}
