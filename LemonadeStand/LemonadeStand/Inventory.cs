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
            Console.Clear();
            Console.WriteLine("Your current inventory");
            Console.WriteLine("Cups: {0}", cups.Count);
            Console.WriteLine("Lemons: {0}", lemons.Count);
            Console.WriteLine("Cups of Sugar: {0}", cupsOfSugar.Count);
            Console.WriteLine("Ice Cubes: {0}", cubesOfIce.Count);

        }

        public void AddCups(int amountOfCupsBought)
        {
            for (int i = 0; i < amountOfCupsBought; i++)
            {
                Cup cup = new Cup();
                cups.Add(cup);

            }
        }

        //public void UseCups()
        //{
        //        int removeCups = playerOne.recipe.TakeCupsOut();
        //        for (int i = 0; i < removeCups; i++)
        //        {
        //            cups.RemoveAt(0);
        //        }
        //}







        public void AddLemons(int amountOfLemonsBought)
        {
            for (int i = 0; i < amountOfLemonsBought; i++)
            {
                Lemon lemon = new Lemon();
                lemons.Add(lemon);

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

        public void AddIce(int amountOfIceBought)
        {
            for (int i = 0; i < amountOfIceBought; i++)
            {
                Ice ice = new Ice();
                cubesOfIce.Add(ice);

            }
        }


    }
}
        
