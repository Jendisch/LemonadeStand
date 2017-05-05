using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {

        //User interface for Game Class


        public static void WelcomePlayerToGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Lemonade Stand!");
        }

        public static void DisplayRules()
        {
            Console.WriteLine("You have 7, 14, or 21 days to make as much money as possible, and you’ve decided to open a lemonade stand! You’ll have complete control over your business, including pricing, quality control, inventory control, and purchasing supplies. Buy your ingredients, set your recipe, and start selling!");
            Console.WriteLine("You can choose to go with the original recipe or you can choose to experiment a little bit and try to see if you can find a better one! Make sure to buy all of your ingredients or you won't be able to sell.");
            Console.WriteLine("You'll also have to deal with the weather... and it will play a big role in amount of potential customers as well as whether people choose to buy your lemonade. My advice to you is to read the weather report every day! When the weather is bad (overcast/rain) don't expect quite as many customers or for them to be in the mood to stop for a drink. On the other hand, if the weather is hot and sunny you might just be able to sell more! Adjust your prices accordingly.");
            Console.WriteLine("You have $30 to start with in your wallet. Good luck! Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static string DisplayNewOrLoad()
        {
            Console.WriteLine("Would you like to start a new game or load a saved game? Type 'new' or 'load'.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static void RetrievePlayerName(Player playerOne)
        {
            Console.WriteLine("Please type your name and press enter.");
            playerOne.playerName = Console.ReadLine();
            Console.WriteLine("Welcome " + playerOne.playerName + ". Let's get started.");
        }

        public static string DecideGameLength()
        {
            Console.WriteLine("\nHow many days would you like to play the game for? Please choose 7, 14, or 21 and hit any key to continue.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static void DisplayNotAValidResponse()
        {
            Console.WriteLine("Not a valid response. Please type one of the options below.");
        }

        public static void DisplayCongrats(Player playerOne)
        {
            Console.WriteLine("Congratulations " + playerOne.playerName + " on finishing the game!");
        }

        public static void DisplayTotalProfit(string profit)
        {
            Console.WriteLine("You ended with a total profit of {0}.", profit);
        }

        public static string DisplayPlayAgainQuestion()
        {
            Console.WriteLine("If you'd like to play again type yes, if not type no.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }


        //User interface for Day Class


        public static void DisplayCurrentWeather(int day, Weather weather)
        {
            Console.WriteLine("Your current weather report for day " + day + " is " + weather.temperature + " degrees and " + weather.condition + ".");
        }

        public static void DisplayAmountOfCups(Player playerOne)
        {
            Console.Clear();
            Console.WriteLine("You now have {0} cups of fantastic lemonade to try to sell!", playerOne.recipe.cupsUsed);
        }

        public static string DisplayAskIfGoingToStore()
        {
            Console.WriteLine("Would you like to go to the store to buy more inventory? Please type 'yes' or 'no'.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static void DisplayDecidePriceOfCup()
        {
            Console.WriteLine("Before the day of selling begins. You'll need to set the cost for 1 cup of lemonade. Please enter your designated price below.");
        }

        public static void DisplayCatchPriceOfCup()
        {
            Console.WriteLine("Something wasn't right with what you entered. Please try entering your price in a format like 0.25 for cents or 1.00 for dollars.");
        }

        public static void DisplayNotEnoughLemonadeMade()
        {
            Console.WriteLine("Oops!! You didn't make enough cups of lemonade for your potential customers!");
        }

        public static void DisplayNetProfit(string netProfit)
        {
            Console.WriteLine("Including money spent on supplies, you have earned a net profit of " + netProfit + ".");
        }

        public static void DisplayNetDeficit(string netDeficit)
        {
            Console.WriteLine("Including money spent on supplies, you have a net deficit of " + netDeficit + ".");
        }

        public static void DisplayDailyProfitAndWallet(Player playerOne, string profit, int number)
        {
            Console.WriteLine("You had " + number + " customers and collected a total of " + profit + ".");
            Console.WriteLine("You currently have " + playerOne.wallet.wallet.ToString("C") + " in your wallet.");
        }



        //User interface for Store Class


        public static string DisplayAskToBuyItems()
        {
            Console.Clear();
            Console.WriteLine("Would you like to buy more 'cups', 'lemons', 'sugar', or 'ice'? Choose one. If you don't need anymore supplies to make lemonade type 'exit' to leave the store.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }


        public static string DisplayBuyMoreCups()
        {
            Console.WriteLine("Cups are sold in groups. 25 cups for $1.00. 50 cups for $1.50. 100 cups for $1.90. How many cups would you like to buy? If you would rather not buy cups, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static string DisplayBuyMoreLemons()
        {
            Console.WriteLine("Lemons are sold in groups. 10 lemons for $0.50. 50 lemons for $2.50. 75 lemons for $4.25. How many lemons would you like to buy? If you would rather not buy lemons, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static string DisplayBuyMoreSugar()
        {
            Console.WriteLine("Sugar is sold in groups of cups. 10 cups for $0.50. 25 cups for $1.75. 50 cups for $3.50. How many cups of sugar would you like to buy? If you would rather not buy any sugar, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static string DisplayBuyMoreIce()
        {
            Console.WriteLine("Ice is sold in groups of ice cubes. 100 cubes for $1.00. 250 cubes for $2.25. 500 cubes for $4.00. How many ice cubes would you like to buy? If you would rather not buy ice, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }


        //User interface for Weather Class


        public static string AskToSeeTomorrowForecast()
        {
            Console.WriteLine("Would you like to see the weather forcast for tomorrow? Please type 'yes' or 'no'.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static void DisplayTomorrowForecast(int forecastedTemperature, string forecastedCondition)
        {
            Console.WriteLine("Your forecasted weather for tomorrow is " + forecastedTemperature + " degrees and " + forecastedCondition + ".");
            Console.WriteLine("Please hit any key to continue.");
            Console.ReadKey();
        }


        //User interface for Recipe Class

            
        public static string DisplayRecipeWelcome()
        {
            Console.WriteLine("\nIt's time to create your lemonade recipe for the day! \nEach pitcher will produce 10 cups of lemonade to be sold.");
            Console.WriteLine("We have a built in recipe for your convenience which includes 6 lemons, 7 cups of sugar, and 30 ice cubes (3 per cup).");
            Console.WriteLine("Would you like to use the general recipe or create your own accomodating the weather? Please enter 'general' or 'create'.");
            Console.WriteLine("Tip: use 3 or more lemons/cups of sugar for your lemonade to have any taste and sell!");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static int DisplayAskNumberOfPitchers(int pitchersUsed)
        {
            Console.WriteLine("It's up to you to decide how many pitchers to make! Remember, each pitcher makes 10 cups. It would be wise to factor in the current forecast in your decision.");
            Console.WriteLine("You can't save any unused cups of lemonade and all of your ice will melt at the end of each day!");
            Console.WriteLine("How many pitchers would you like to make?");
            pitchersUsed = int.Parse(Console.ReadLine());
            return pitchersUsed;
        }

        public static void DisplayNotEnoughItems()
        {
            Console.WriteLine("You don't have enough supplies! Choose a smaller number.");
        }

        public static int DisplayNumberOfPitchers(int pitchersUsed)
        {
            Console.WriteLine("You chose to make " + pitchersUsed + " pitchers of lemonade for the day.");
            return pitchersUsed;
        }

        public static int DisplayLemonsUsed(int lemonsUsed)
        {
            Console.WriteLine("Time to create your own lemonade recipe!");
            Console.WriteLine("How many lemons per pitcher would you like to add?");
            lemonsUsed = int.Parse(Console.ReadLine());
            return lemonsUsed;
        }

        public static int DisplaySugarUsed(int sugarUsed)
        {
            Console.WriteLine("How many cups of sugar per pitcher would you like to add?");
            sugarUsed = int.Parse(Console.ReadLine());
            return sugarUsed;
        }

        public static int DisplayIceUsed(int iceUsed)
        {
            Console.WriteLine("How many ice cubes per pitcher would you like to add?");
            iceUsed = int.Parse(Console.ReadLine());
            return iceUsed;
        }

        public static int DisplayCustomPitcher(int pitchersUsed)
        {
            Console.WriteLine("It's up to you to decide how many pitchers to make! Remember, each pitcher makes 10 cups. It would be wise to factor in the current forecast in your decision.");
            Console.WriteLine("You can't save any unused lemonade as well.");
            Console.WriteLine("How many pitchers would you like to make?");
            pitchersUsed = int.Parse(Console.ReadLine());
            return pitchersUsed;
        }

        public static void DisplayCustomRecipe(int lemonsUsed, int sugarUsed, int iceUsed)
        {
            Console.WriteLine("Your recipe consists of {0} lemons, {1} cups of sugar, and {2} cubes of ice per pitcher ({3} per cup).", lemonsUsed, sugarUsed, iceUsed, (iceUsed / 10));
            Console.ReadKey();
        }


        //User interface for Inventory Class


        public static void DisplayInventory(int cupCount, int lemonCount, int sugarCount, int iceCount)
        {
            Console.Clear();
            Console.WriteLine("Your current inventory");
            Console.WriteLine("Cups: {0}", cupCount);
            Console.WriteLine("Lemons: {0}", lemonCount);
            Console.WriteLine("Cups of Sugar: {0}", sugarCount);
            Console.WriteLine("Ice Cubes: {0}", iceCount);
        }


        //User interface for Game Class


        public static void DisplayMoneyAvailable(Double wallet)
        {
            Console.WriteLine("Money available to spend = " + wallet.ToString("C"));
        }

        public static void DisplayNotEnoughFunds()
        {
            Console.WriteLine("You do not have enough funds to make this purchase. Press any key to continue.");
            Console.ReadKey();
        }


        //User interface for SavedGame Class


        public static string DisplayAskToSaveGame()
        {
            Console.WriteLine("Would you like to save your game? Type 'yes' or 'no'.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static string ReceiveUniqueName()
        {
            Console.WriteLine("Please enter a unique name to save your game under (different than your name given at the beginning of the game). It can contain a mixture of numbers or characters.");
            Console.WriteLine("If you are updating an existing game. Use the same unique name.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static string AskForUniqueName()
        {
            Console.WriteLine("Please enter your unique name that your gave is saved under!");
            Console.WriteLine("If you can't remember your unique game name, please type 'idk' to go back.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static void DisplayCantFindGame()
        {
            Console.WriteLine("I'm sorry we couldn't find your game! Please try again.");
        }


    }
}