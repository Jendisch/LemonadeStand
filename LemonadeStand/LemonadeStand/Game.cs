using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
       
        public Player playerOne;
        public int lengthOfGame;
        public int currentDay;
        public Game()
        {

        }

        public Game(Player playerOne, int lengthOfGame)
        {
            this.playerOne = playerOne;
            this.lengthOfGame = lengthOfGame;
        }


        public void StartGame(Random random)
        {
            UserInterface.DisplayRules();
            GetPlayerName();
            ChooseGameLength();
            Day day = new Day(playerOne);
            day.TakeTurn(lengthOfGame, day, random);
            ShowEndingStats();
            AskToPlayAgain(random);
        }

        public void LoadDirectlyToTurn()
        {
            Random newRandom = new Random();
            Day day = new Day(playerOne);
            day.TakeTurn(lengthOfGame, day, newRandom, currentDay);
        }   
        
        private void GetPlayerName()
        {
            playerOne = new Player();
            UserInterface.RetrievePlayerName(playerOne);
        }

        private void ChooseGameLength()
        {
            string choice = UserInterface.DecideGameLength();
            switch (choice)
            {
                case "7":
                    lengthOfGame = 7;
                    break;
                case "14":
                    lengthOfGame = 14;
                    break;
                case "21":
                    lengthOfGame = 21;
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    ChooseGameLength();
                    break;
            }
            Console.Clear();
        }

        private void ShowEndingStats()
        {
            UserInterface.DisplayCongrats(playerOne);
            double totalProfit = (playerOne.wallet.wallet - 30);
            string profit = totalProfit.ToString("C");
            UserInterface.DisplayTotalProfit(profit);
        }

        private void AskToPlayAgain(Random random)
        {
            string choice = UserInterface.DisplayPlayAgainQuestion();
            if (choice == "yes")
            {
                StartGame(random);
            }
            else if (choice == "no")
            {
                return;
            }
            else
            {
                UserInterface.DisplayNotAValidResponse();
                AskToPlayAgain(random);
            }
        }
    }
}
