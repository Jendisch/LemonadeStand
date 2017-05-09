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

        public Inventory()
        {

        }

        public Inventory(List<Cup> cups, List<Lemon> lemons, List<Sugar> cupsOfSugar)
        {
            this.cups = cups;
            this.lemons = lemons;
            this.cupsOfSugar = cupsOfSugar;
        }

        public Inventory(int cups, int lemons, int sugar)
        {
            AddCups(cups);
            AddLemons(lemons);
            AddSugar(sugar);
        }


        public void ShowItemInventoryPlayerOne(Player playerOne)
        {
            int cupCount = cups.Count;
            int lemonCount = lemons.Count;
            int sugarCount = cupsOfSugar.Count;
            int iceCount = cubesOfIce.Count;
            UserInterface.DisplayInventoryPlayerOne(playerOne, cupCount, lemonCount, sugarCount, iceCount);
        }

        public void ShowItemInventoryPlayerTwo(Player playerTwo)
        {
            int cupCount = cups.Count;
            int lemonCount = lemons.Count;
            int sugarCount = cupsOfSugar.Count;
            int iceCount = cubesOfIce.Count;
            UserInterface.DisplayInventoryPlayerTwo(playerTwo, cupCount, lemonCount, sugarCount, iceCount);
        }

        public void AddCups(int amountOfCupsBought)
        {
            for (int i = 0; i < amountOfCupsBought; i++)
            {
                Cup cup = new Cup();
                cups.Add(cup);
            }
        }

        private void RemoveCups(Player playerOne)
        {
                int removedCups = playerOne.recipe.RemoveCupsFromInventory();
                for (int i = 0; i < removedCups; i++)
                {
                    cups.RemoveAt(0);
                }
        }

        private void RemoveCupsPlayerTwo(Player playerTwo)
        {
            int removedCups = playerTwo.recipe.RemoveCupsFromInventory();
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

        private void RemoveLemons(Player playerOne)
        {
            int removedLemons = playerOne.recipe.RemoveLemonsFromInventory();
            for (int i = 0; i < removedLemons; i++)
            {
                lemons.RemoveAt(0);
            }
        }

        private void RemoveLemonsPlayerTwo(Player playerTwo)
        {
            int removedLemons = playerTwo.recipe.RemoveLemonsFromInventory();
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

        private void RemoveSugar(Player playerOne)
        {
            int removedSugar = playerOne.recipe.RemoveSugarFromInventory();
            for (int i = 0; i < removedSugar; i++)
            {
                cupsOfSugar.RemoveAt(0);
            }
        }

        private void RemoveSugarPlayerTwo(Player playerTwo)
        {
            int removedSugar = playerTwo.recipe.RemoveSugarFromInventory();
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

        private void RemoveIce(Player playerOne)
        {
            int removedIce = playerOne.recipe.RemoveIceFromInventory();
            for (int i = 0; i < removedIce; i++)
            {
                cubesOfIce.RemoveAt(0);
            }
        }

        private void RemoveIcePlayerTwo(Player playerTwo)
        {
            int removedIce = playerTwo.recipe.RemoveIceFromInventory();
            for (int i = 0; i < removedIce; i++)
            {
                cubesOfIce.RemoveAt(0);
            }
        }

        private void RemoveAllIceFromInventoryAfterTurn()
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

        public void RemoveItemsAfterMakingLemonadePlayerTwo(Player playerTwo)
        {
            RemoveCupsPlayerTwo(playerTwo);
            RemoveLemonsPlayerTwo(playerTwo);
            RemoveSugarPlayerTwo(playerTwo);
            RemoveIcePlayerTwo(playerTwo);
            RemoveAllIceFromInventoryAfterTurn();
        }
    }
}
        
