using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Wallet
    {

        public double wallet = 20;

        public void ShowMoneyAvailable()
        {
            Console.WriteLine("Money available to spend = " + wallet.ToString("C"));
        }

        public int CheckIfBrokeForCups(double price, int amountOfCupsBought)
        {
            if (wallet - price >= 0)
            {
                wallet -= price;
                return amountOfCupsBought;
            }
            else
            {
                Console.WriteLine("You do not have enough funds to make this purchase. Press any key to continue.");
                Console.ReadKey();
                return amountOfCupsBought = 0;
            }
        }

        public int CheckIfBrokeForLemons(double price, int amountOfLemonsBought)
        {
            if (wallet - price >= 0)
            {
                wallet -= price;
                return amountOfLemonsBought;
            }
            else
            {
                Console.WriteLine("You do not have enough funds to make this purchase. Press any key to continue.");
                Console.ReadKey();
                return amountOfLemonsBought = 0;
            }
        }

        public int CheckIfBrokeForSugar(double price, int amountOfSugarBought)
        {
            if (wallet - price >= 0)
            {
                wallet -= price;
                return amountOfSugarBought;
            }
            else
            {
                Console.WriteLine("You do not have enough funds to make this purchase. Press any key to continue.");
                Console.ReadKey();
                return amountOfSugarBought = 0;
            }
        }

        public int CheckIfBrokeForIce(double price, int amountOfIceBought)
        {
            if (wallet - price >= 0)
            {
                wallet -= price;
                return amountOfIceBought;
            }
            else
            {
                Console.WriteLine("You do not have enough funds to make this purchase. Press any key to continue.");
                Console.ReadKey();
                return amountOfIceBought = 0;
            }
        }


    }
}
