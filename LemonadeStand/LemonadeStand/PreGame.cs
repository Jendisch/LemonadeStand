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
        public void ChooseNewOrOldGame(Random random)
        {
           
            UserInterface.WelcomePlayerToGame();
            string choice = UserInterface.DisplayNewOrLoad();
            switch (choice)
            {
                case "new":
                    game = new Game();
                    game.StartGame(random);
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
