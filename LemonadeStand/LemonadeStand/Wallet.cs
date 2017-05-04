using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Wallet
    {

        public double wallet = 30;

        public Wallet()
        {

        }

        public Wallet(double wallet)
        {
            this.wallet = wallet;
        }

        public void ShowMoneyAvailable()
        {
            UserInterface.DisplayMoneyAvailable(wallet);
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
                UserInterface.DisplayNotEnoughFunds();
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
                UserInterface.DisplayNotEnoughFunds();
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
                UserInterface.DisplayNotEnoughFunds();
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
                UserInterface.DisplayNotEnoughFunds();
                return amountOfIceBought = 0;
            }
        }


    }
}
