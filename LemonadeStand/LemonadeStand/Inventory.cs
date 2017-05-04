using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {


        public List<Cup> cups = new List<Cup>();
        public List<Lemon> lemons = new List<Lemon>();
        public List<Sugar> cupsOfSugar = new List<Sugar>();
        public List<Ice> cubesOfIce = new List<Ice>();


        public void ShowItemInventory()
        {
            int cupCount = cups.Count;
            int lemonCount = lemons.Count;
            int sugarCount = cupsOfSugar.Count;
            int iceCount = cubesOfIce.Count;
            UserInterface.DisplayInventory(cupCount, lemonCount, sugarCount, iceCount);
        }

        public void AddCups(int amountOfCupsBought)
        {
            for (int i = 0; i < amountOfCupsBought; i++)
            {
                Cup cup = new Cup();
                cups.Add(cup);
            }
        }

        public void RemoveCups(Player playerOne)
        {
                int removedCups = playerOne.recipe.RemoveCupsFromInventory();
                for (int i = 0; i < removedCups; i++)
                {
                    cups.RemoveAt(0);
                }
        }

        public void AddLemons(int amountOfLemonsBought)
        {
            for (int i = 0; i < amountOfLemonsBought; i++)
            {
                Lemon lemon = new Lemon();
                lemons.Add(lemon);
            }
        }

        public void RemoveLemons(Player playerOne)
        {
            int removedLemons = playerOne.recipe.RemoveLemonsFromInventory();
            for (int i = 0; i < removedLemons; i++)
            {
                lemons.RemoveAt(0);
            }
        }

        public void AddSugar(int amountOfSugarBought)
        {
            for (int i = 0; i < amountOfSugarBought; i++)
            {
                Sugar sugar = new Sugar();
                cupsOfSugar.Add(sugar);
            }
        }

        public void RemoveSugar(Player playerOne)
        {
            int removedSugar = playerOne.recipe.RemoveSugarFromInventory();
            for (int i = 0; i < removedSugar; i++)
            {
                cupsOfSugar.RemoveAt(0);
            }
        }

        public void AddIce(int amountOfIceBought)
        {
            for (int i = 0; i < amountOfIceBought; i++)
            {
                Ice ice = new Ice();
                cubesOfIce.Add(ice);
            }
        }

        public void RemoveIce(Player playerOne)
        {
            int removedIce = playerOne.recipe.RemoveIceFromInventory();
            for (int i = 0; i < removedIce; i++)
            {
                cubesOfIce.RemoveAt(0);
            }
        }

        public void RemoveAllIceFromInventoryAfterTurn()
        {
            int iceCount = cubesOfIce.Count;
            for (int i = 0; i < iceCount; i++)
            {
                cubesOfIce.RemoveAt(0);
            }
        }

        public void RemoveItemsAfterMakingLemonade(Player playerOne)
        {
            RemoveCups(playerOne);
            RemoveLemons(playerOne);
            RemoveSugar(playerOne);
            RemoveIce(playerOne);
            RemoveAllIceFromInventoryAfterTurn();
        }

    }
}
        
