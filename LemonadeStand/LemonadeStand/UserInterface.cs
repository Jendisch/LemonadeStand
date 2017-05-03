using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {

        //public class Inventory
        //{
        //    List<Lemon> lemons = new List<Lemon>();
        //    List<Sugar> sugar = new List<Sugar>();
        //    List<Ice> ice = new List<Ice>();
        //    List<Cup> cups = new List<Cup>();
        //    public void AddLemons(int NumberOfLemonsNeeded)
        //    {
        //        for (int i = 0; i < NumberOfLemonsNeeded; i++)
        //        {
        //            Lemon lemon = new Lemon();
        //            lemons.Add(lemon);
        //        }
        //        Console.WriteLine("You currently have {0} lemons.\n\n", lemons.Count);
        //    }

        //    public void RemoveLemons(Player player)
        //    {
        //        try
        //        {
        //            int lemonsToRemove = player.recipe.TakeLemonsOut();
        //            for (int i = 0; i < lemonsToRemove; i++)
        //            {
        //                lemons.RemoveAt(0);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Oops! Looks like you need modify your recipe. Let's try again.");
        //            player.recipe.ChooseRecipe();
        //            throw;
        //        }
        //    }



        //    public void AddSugar(int NumberOfSugarNeeded)
        //    {
        //        for (int i = 0; i < NumberOfSugarNeeded; i++)
        //        {
        //            Sugar sugar = new Sugar();
        //            this.sugar.Add(sugar);
        //        }
        //        Console.WriteLine("You just bought {0} cups of Sugar.\n\n", sugar.Count);
        //    }
        //    public void RemoveSugar(Player player)
        //    {
        //        try
        //        {
        //            int sugarToRemove = player.recipe.TakeSugarOut();
        //            for (int i = 0; i < sugarToRemove; i++)
        //            {
        //                sugar.RemoveAt(0);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Oops! Looks like you need modify your recipe. Let's try again.");
        //            player.recipe.ChooseRecipe();
        //            throw;
        //        }
        //    }






        //    public void AddIce(int NumberOfIceCubesNeeded)
        //    {
        //        for (int i = 0; i < NumberOfIceCubesNeeded; i++)
        //        {
        //            Ice ice = new Ice();
        //            this.ice.Add(ice);
        //        }
        //        Console.WriteLine("You currently have {0} ice cubes.\n\n", ice.Count);
        //    }
        //    public void RemoveIce(Player player)
        //    {
        //        try
        //        {
        //            int iceToRemove = player.recipe.TakeIceOut();
        //            for (int i = 0; i < iceToRemove; i++)
        //            {
        //                ice.RemoveAt(0);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Oops! Looks like you need modify your recipe. Let's try again.");
        //            player.recipe.ChooseRecipe();
        //            throw;
        //        }

        //    }








        //    public void AddCups(int NumberOfCupsNeeded)
        //    {
        //        for (int i = 0; i < NumberOfCupsNeeded; i++)
        //        {
        //            Cup cup = new Cup();
        //            cups.Add(cup);
        //        }
        //        Console.WriteLine("You currently have {0} cups.\n\n", cups.Count);
        //    }
        //    public void RemoveCups(Player player)
        //    {
        //        try
        //        {
        //            int removeCups = player.recipe.TakeCupsOut();
        //            for (int i = 0; i < removeCups; i++)
        //            {
        //                cups.RemoveAt(0);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Oops! Looks like you need modify your recipe. Let's try again.");
        //            player.recipe.ChooseRecipe();
        //            throw;
        //        }
        //    }








        //    public void ShowAllProductInventory()
        //    {
        //        Console.WriteLine("You currently have {0} lemons.\n\n", lemons.Count);
        //        Console.WriteLine("You currently have {0} cups of sugar.\n\n", sugar.Count);
        //        Console.WriteLine("You currently have {0} ice cubes.\n\n", ice.Count);
        //        Console.WriteLine("You currently have {0} cups.\n\n", cups.Count);
        //    }
        //    public void RemoveItemAfterLemonadeWasMade(Player player)
        //    {
        //        RemoveLemons(player);
        //        RemoveSugar(player);
        //        RemoveIce(player);
        //        RemoveCups(player);
        //    }
        //}

    }
}



//public class Ice : ICost
//{
//    double iceCost = .05;
//    string iceName;
//    //public void setIceCost()
//    //{
//    //    iceCost = 0.05;
//    //}
//    public double GetCost()
//    {
//        return iceCost;
//    }
//    public void setIceName()
//    {
//        iceName = "Ice";
//    }
//    public string getIceName()
//    {
//        return iceName;
//    }
//}