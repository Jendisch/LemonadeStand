using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {

        Inventory inventory;
        public Recipe(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public int pitchersUsed = 0;
        public int cupsUsedPerPitcher = 10;
        public int cupsUsed;
        public int lemonsUsed = 6;
        public int sugarUsed = 7;
        public int iceUsed = 30;

        public int removedCupsFromInventory;
        public int removedLemonsFromInventory;
        public int removedSugarFromInventory;
        public int removedIceFromInventory;

        public void MakeRecipe()
        {
            string choice = UserInterface.DisplayRecipeWelcome();
            switch (choice)
            {
                case "general":
                    DecideNumberOfPitchers();
                    ShowCustomRecipe();
                    break;
                case "create":
                    DecideNumberOfPitchersCustom();
                    CheckInventoryCups();
                    DecideLemonAmountForRecipe();
                    CheckInventoryLemons();
                    DecideSugarAmountForRecipe();
                    CheckInventorySugar();
                    DecideIceAmountForRecipe();
                    CheckInventoryIce();
                    ShowCustomRecipe();

                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    MakeRecipe();
                    break;
            }
        }

        public int DecideNumberOfPitchers()
        {
            pitchersUsed = UserInterface.DisplayAskNumberOfPitchers(pitchersUsed);
            cupsUsed = pitchersUsed * cupsUsedPerPitcher;
            if ((inventory.lemons.Count - (lemonsUsed * pitchersUsed) >= 0) && (inventory.cupsOfSugar.Count - (sugarUsed * pitchersUsed) >= 0) && (inventory.cubesOfIce.Count - (iceUsed * pitchersUsed) >= 0) && (inventory.cups.Count - cupsUsed >= 0))
            {
                UserInterface.DisplayNumberOfPitchers(pitchersUsed);
                return pitchersUsed;
            }
            else
            {
                UserInterface.DisplayNotEnoughItems();
                return DecideNumberOfPitchers();
            }
        }

        public int DecideLemonAmountForRecipe()
        {
            lemonsUsed = UserInterface.DisplayLemonsUsed(lemonsUsed);
            return lemonsUsed;
        }

        public void CheckInventoryLemons()
        {
            if (inventory.lemons.Count - (lemonsUsed * pitchersUsed) >= 0)
            {
                return;
            }
            else
            {
                UserInterface.DisplayNotEnoughItems();
                DecideLemonAmountForRecipe();
            }
        }

        public int DecideSugarAmountForRecipe()
        {
            sugarUsed = UserInterface.DisplaySugarUsed(sugarUsed);
            return sugarUsed;
        }

        public void CheckInventorySugar()
        {
            if (inventory.cupsOfSugar.Count - (sugarUsed * pitchersUsed) >= 0)
            {
                return;
            }
            else
            {
                UserInterface.DisplayNotEnoughItems();
                DecideSugarAmountForRecipe();
            }
        }

        public int DecideIceAmountForRecipe()
        {
            iceUsed = UserInterface.DisplayIceUsed(iceUsed);
            return iceUsed;
        }

        public void CheckInventoryIce()
        {
            if (inventory.cubesOfIce.Count - (iceUsed * pitchersUsed) >= 0)
            {
                return;
            }
            else
            {
                UserInterface.DisplayNotEnoughItems();
                DecideIceAmountForRecipe();
            }
        }
        public void CheckInventoryCups()
        {
            if (inventory.cups.Count - cupsUsed >= 0)
            {
                return;
            }
            else
            {
                UserInterface.DisplayNotEnoughItems();
                DecideNumberOfPitchersCustom();
            }
        }

        public int DecideNumberOfPitchersCustom()
        {
            pitchersUsed = UserInterface.DisplayCustomPitcher(pitchersUsed);
            cupsUsed = pitchersUsed * cupsUsedPerPitcher;
            return pitchersUsed;
        }

        public void ShowCustomRecipe()
        {
            UserInterface.DisplayCustomRecipe(lemonsUsed, sugarUsed, iceUsed);
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

