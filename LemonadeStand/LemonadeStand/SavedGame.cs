using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class SavedGame
    {
        
        public string uniquePlayerName;

        public SavedGame(Player playerOne, int dayNumber, int savedLengthOfGame, double totalProfit)
        {
            
        }


        public void AskToSaveGame(Player playerOne, int dayNumber, int savedLengthOfGame, double totalProfit)
        {
            string choice = UserInterface.DisplayAskToSaveGame();
            if (choice == "yes")
            {
                uniquePlayerName = UserInterface.ReceiveUniqueName();
                CheckDatabaseForSavedGame(playerOne, dayNumber, savedLengthOfGame, totalProfit);
            }
            else if (choice == "no")
            {
                return;
            }
            else
            {
                UserInterface.DisplayNotAValidResponse();
                AskToSaveGame(playerOne, dayNumber, savedLengthOfGame, totalProfit);
            }
        }

        public void CheckDatabaseForSavedGame(Player playerOne, int dayNumber, int savedLengthOfGame, double totalProfit)
        {
            DatabaseConnection connect = new DatabaseConnection();
            bool player = connect.SearchForUniqueName(uniquePlayerName);
            if (player == true)
            {
                connect.UpdateCurrentDatabaseRecord(playerOne, dayNumber, savedLengthOfGame, totalProfit, uniquePlayerName);
            }
            else if (player == false)
            {
                connect.InsertIntoDatabase(playerOne, dayNumber, savedLengthOfGame, totalProfit, uniquePlayerName);
            }
        }

    }
}
