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


        public void StartGame()
        {
            WelcomeToGame();
            GetPlayerName();
            ChooseGameLength();
            Day day = new Day(playerOne);
            day.TakeTurn(lengthOfGame);
            Console.ReadKey();
        }





        private void WelcomeToGame()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            Console.WriteLine("You have 7, 14, or 21 days to make as much money as possible, and you’ve decided to open a lemonade stand! You’ll have complete control over your business, including pricing, quality control, inventory control, and purchasing supplies. Buy your ingredients, set your recipe, and start selling!");
            Console.WriteLine("You can choose to go with the original recipe or you can choose to experiment a little bit and try to see if you can find a better one! Make sure to buy all of your ingredients or you won't be able to sell.");
            Console.WriteLine("You'll also have to deal with the weather... and it will play a big role in amount of potential customers as well as whether people choose to buy your lemonade. My advice to you is to read the weather report every day! When the weather is bad (overcast/rain) don't expect quite as many customers or for them to be in the mood to stop for a drink. On the other hand, if the weather is hot and sunny you might just be able to sell more! Adjust your prices accordingly.");
            Console.WriteLine("Good luck! Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        } 

        private void GetPlayerName()
        {
            playerOne = new Player();
            Console.WriteLine("Please type your name and press enter.");
            playerOne.playerName = Console.ReadLine();
            Console.WriteLine("Welcome " + playerOne.playerName + ". Let's get started.");
        }

        private int ChooseGameLength()
        {
            Console.WriteLine("\nHow many days would you like to play the game for? Please choose 7, 14, or 21 and hit any key to continue.");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    lengthOfGame = 1;
                    break;
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
                    Console.WriteLine("Not a valid response. Please type one of the options below.");
                    ChooseGameLength();
                    break;
            }
            Console.Clear();
            return lengthOfGame;
        }

    }
}
