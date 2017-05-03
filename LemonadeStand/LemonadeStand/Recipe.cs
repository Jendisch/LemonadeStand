using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {

        Player playerOne;
        public Recipe(Player player)
        {
            playerOne = player;
        }

        public Recipe()
        {
        }

        public int pitchersUsed = 0;
        public int cupsUsedPerPitcher = 12;
        public int cupsUsed;
        public int lemonsUsed = 6;
        public int sugarUsed = 7;
        public int iceUsed = 25;

        public int removedCupsFromInventory;
        public int removedLemonsFromInventory;
        public int removedSugarFromInventory;
        public int removedIceFromInventory;


        public void MakeRecipe(Player playerOne)
        {
            
            Console.WriteLine("It's time to create your lemonade recipe for the day! \nEach pitcher will produce 12 cups of lemonade to be sold.");
            Console.WriteLine("We have a built in recipe for your convenience which includes 5 lemons, 7 cups of sugar, and 36 ice cubes (3 per cup).");
            Console.WriteLine("Would you like to use the general recipe or create your own accomodating the weather? Please enter 'general' or 'create'.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "general":
                    DecideNumberOfPitchers(playerOne);
                    ShowCustomRecipe(playerOne);
                    break;
                case "create":
                    DecideLemonAmountForRecipe(playerOne);
                    DecideSugarAmountForRecipe(playerOne);
                    DecideIceAmountForRecipe(playerOne);
                    DecideNumberOfPitchers(playerOne);
                    ShowCustomRecipe(playerOne);

                    break;
                default:
                    Console.WriteLine("Not a valid response. Please type one of the options below.");
                    MakeRecipe(playerOne);
                    break;
            }
        }

        public int DecideNumberOfPitchers(Player playerOne)
        {
            Console.WriteLine("It's up to you to decide how many pitchers to make! Remember, each pitcher makes 12 cups. It would be wise to factor in the current forecast in your decision.");
            Console.WriteLine("You can't save any unused lemonade as well.");
            Console.WriteLine("How many pitchers would you like to make?");
            pitchersUsed = int.Parse(Console.ReadLine());
            cupsUsed = pitchersUsed * 12;
            if ((playerOne.inventory.lemons.Count - lemonsUsed >= 0) && (playerOne.inventory.cupsOfSugar.Count - sugarUsed >= 0) && (playerOne.inventory.cubesOfIce.Count - iceUsed >= 0) && (playerOne.inventory.cups.Count - cupsUsed >= 0))
            {
                Console.WriteLine("You chose to make " + pitchersUsed + " pitchers of lemonade for the day.");
                return pitchersUsed;
            }
            else
            {
                Console.WriteLine("You don't have enough supplies to make that many pitchers!");
                DecideNumberOfPitchers(playerOne);
                return pitchersUsed;
            }
        }

        public int DecideLemonAmountForRecipe(Player playerOne)
        {
            Console.WriteLine("Time to create your own lemonade recipe!");
            Console.WriteLine("How many lemons per pitcher would you like to add?");
            lemonsUsed = int.Parse(Console.ReadLine());
            if (playerOne.inventory.lemons.Count - lemonsUsed >= 0)
            {
                return lemonsUsed;
            }
            else
            {
                Console.WriteLine("You don't have enough lemons! Choose less.");
                DecideLemonAmountForRecipe(playerOne);
                return lemonsUsed;
            }
        }

        public int DecideSugarAmountForRecipe(Player playerOne)
        {
            Console.WriteLine("How many cups of sugar per pitcher would you like to add?");
            sugarUsed = int.Parse(Console.ReadLine());
            if (playerOne.inventory.cupsOfSugar.Count - sugarUsed >= 0)
            {
                return sugarUsed;
            }
            else
            {
                Console.WriteLine("You don't have enough cups of sugar! Choose less.");
                DecideSugarAmountForRecipe(playerOne);
                return sugarUsed;
            }
        }

        public int DecideIceAmountForRecipe(Player playerOne)
        {
            Console.WriteLine("How many ice cubes per pitcher would you like to add?");
            iceUsed = int.Parse(Console.ReadLine());
            if (playerOne.inventory.cubesOfIce.Count - iceUsed >= 0)
            {
                return iceUsed;
            }
            else
            {
                Console.WriteLine("You don't have enough ice cubes! Choose less.");
                DecideIceAmountForRecipe(playerOne);
                return iceUsed;
            }
        }

        public int DecidePitcherAmountForRecipe(Player playerOne)
        {
            Console.WriteLine("It's up to you to decide how many pitchers to make! Remember, each pitcher makes 12 cups. It would be wise to factor in the current forecast in your decision.");
            Console.WriteLine("You can't save any unused lemonade as well.");
            Console.WriteLine("How many pitchers would you like to make?");
            pitchersUsed = int.Parse(Console.ReadLine());
            cupsUsed = pitchersUsed * 12;
            if ((playerOne.inventory.lemons.Count - lemonsUsed >= 0) && (playerOne.inventory.cupsOfSugar.Count - sugarUsed >= 0) && (playerOne.inventory.cubesOfIce.Count - iceUsed >= 0) && (playerOne.inventory.cups.Count - cupsUsed >= 0))
            {
                Console.WriteLine("You chose to make " + pitchersUsed + " pitchers of lemonade for the day.");
                return pitchersUsed;
            }
            else
            {
                Console.WriteLine("You don't have enough supplies to make that many pitchers!");
                DecideNumberOfPitchers(playerOne);
                return pitchersUsed;
            }
        }

        public void ShowCustomRecipe(Player playerOne)
        {
            Console.WriteLine("Your recipe consists of {0} lemons, {1} cups of sugar, {2} cubes of ice, and {3} cups per pitcher",lemonsUsed, sugarUsed, iceUsed, cupsUsedPerPitcher);
            Console.ReadKey();
        }

        public int RemoveCupsFromInventory()
        {
                removedCupsFromInventory = pitchersUsed * cupsUsedPerPitcher;
                return removedCupsFromInventory;
        }

        public int RemoveLemonsFromInventory()
        {
            removedLemonsFromInventory = pitchersUsed * lemonsUsed;
            return removedLemonsFromInventory;
        }

        public int RemoveSugarFromInventory()
        {
            removedSugarFromInventory = pitchersUsed * sugarUsed;
            return removedSugarFromInventory;
        }

        public int RemoveIceFromInventory()
        {
            removedIceFromInventory = pitchersUsed * iceUsed;
            return removedIceFromInventory;
        }







    }
}

