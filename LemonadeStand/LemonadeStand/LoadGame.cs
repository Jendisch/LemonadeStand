using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class LoadGame
    {
        public LoadGame()
        {

        }
        
        public Game LoadOldGame(string uniquePlayerName)
        {
            VariableObjects variables = FindSavedGame(uniquePlayerName);
            if (variables == null)
            {
                return null;
            }
            double cash = Convert.ToDouble(variables.walletFromLoad);
            Wallet wallet = new Wallet(cash);
            Inventory inventory = new Inventory(variables.cupsFromLoad, variables.lemonsFromLoad, variables.sugarFromLoad);
            Player playerOne = new Player(variables.playerNameFromLoad, inventory, wallet);
            Game game = new Game(playerOne, variables.gameLengthFromLoad);
            game.currentDay = variables.dayNumberFromLoad + 1;
            return game;
        }

        public VariableObjects FindSavedGame(string uniquePlayerName)
        {
                DatabaseConnection connect = new DatabaseConnection();
                bool player = connect.SearchForUniqueName(uniquePlayerName);
                if (player)
                {
                    return connect.LoadPreviousDatabaseRecord(uniquePlayerName);
                }
                else
                {
                    UserInterface.DisplayCantFindGame();
                return null;
                }
            }
        }


}
