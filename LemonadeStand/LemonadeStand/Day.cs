using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {

        Player playerOne;
        public Day(Player player)
        {
            playerOne = player;
        }

        public void TakeTurn(int lengthOfGame)
        {
            for (var i = 1; i <= lengthOfGame; i++)
            {
                Store store = new Store(playerOne);
                Weather weather = new Weather();
                Console.Clear();
                weather.GetCurrentForecast();
                Console.WriteLine("Your current weather report for day " + i + " is " + weather.temperature + " degrees and " + weather.condition + ".");
                weather.GetWeatherForcast();
                DisplayInventoryAndMoney();
                GoToStore(store);
                DisplayInventoryAndMoney();
                playerOne.recipe.MakeRecipe(playerOne);
            }
        }




        public void GoToStore(Store store)
        {
            Console.WriteLine("Would you like to go to the store to buy more inventory? Please type 'yes' or 'no'.");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                store.BuyFromStore();
            }
            else if (choice == "no")
            {
                return;
            }
            else
            {
                Console.WriteLine("Not a valid response. Please type one of the options below.");
                GoToStore(store);
            }
        }

        public void DisplayInventoryAndMoney()
        {
            playerOne.inventory.ShowItemInventory();
            playerOne.wallet.ShowMoneyAvailable();
        }


    }
}

