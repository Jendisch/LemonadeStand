using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {

        Player playerOne;
        public Store(Player player)
        {
            playerOne = player;
        }

        Cup cup = new Cup();
        Lemon lemon = new Lemon();
        Sugar sugar = new Sugar();
        Ice ice = new Ice();

        public double price;
        public int amountOfCupsBought = 0;
        public int amountOfLemonsBought = 0;
        public int amountOfSugarBought = 0;
        public int amountOfIceBought = 0;
        public double moneySpentOnCups = 0;
        public double moneySpentOnLemons = 0;
        public double moneySpentOnSugar = 0;
        public double moneySpentOnIce = 0;

        public void BuyFromStore()
        {
            string choice = UserInterface.DisplayAskToBuyItems();
            switch (choice)
            {
                case "cups":
                    playerOne.inventory.AddCups(BuyMoreCups());
                    BuyFromStore();
                    break;
                case "lemons":
                    playerOne.inventory.AddLemons(BuyMoreLemons());
                    BuyFromStore();
                    break;
                case "sugar":
                    playerOne.inventory.AddSugar(BuyMoreSugar());
                    BuyFromStore();
                    break;
                case "ice":
                    playerOne.inventory.AddIce(BuyMoreIce());
                    BuyFromStore();
                    break;
                case "exit":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    BuyFromStore();
                    break;
            }
        }

        public int BuyMoreCups()
        {
            string choice = UserInterface.DisplayBuyMoreCups();
            switch (choice)
            {
                case "25":
                    amountOfCupsBought = 25;
                    price = cup.GetLowPrice();
                    amountOfCupsBought = playerOne.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    moneySpentOnCups += price;
                    return amountOfCupsBought;
                case "50":
                    amountOfCupsBought = 50;
                    price = cup.GetMediumPrice();
                    amountOfCupsBought = playerOne.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    moneySpentOnCups += price;
                    return amountOfCupsBought;
                case "100":
                    amountOfCupsBought = 100;
                    price = cup.GetHighPrice();
                    amountOfCupsBought = playerOne.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    moneySpentOnCups += price;
                    return amountOfCupsBought;
                case "exit":
                    return amountOfCupsBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreCups();
            }
        }

        public int BuyMoreLemons()
        {
            string choice = UserInterface.DisplayBuyMoreLemons();
            switch (choice)
            {
                case "10":
                    amountOfLemonsBought = 10;
                    price = lemon.GetLowPrice();
                    amountOfLemonsBought = playerOne.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    moneySpentOnLemons += price;
                    return amountOfLemonsBought;
                case "50":
                    amountOfLemonsBought = 50;
                    price = lemon.GetMediumPrice();
                    amountOfLemonsBought = playerOne.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    moneySpentOnLemons += price;
                    return amountOfLemonsBought;
                case "75":
                    amountOfLemonsBought = 75;
                    price = lemon.GetHighPrice();
                    amountOfLemonsBought = playerOne.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    moneySpentOnLemons += price;
                    return amountOfLemonsBought;
                case "exit":
                    return amountOfLemonsBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreLemons();
            }
        }

        public int BuyMoreSugar()
        {
            string choice = UserInterface.DisplayBuyMoreSugar();
            switch (choice)
            {
                case "10":
                    amountOfSugarBought = 10;
                    price = sugar.GetLowPrice();
                    amountOfSugarBought = playerOne.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    moneySpentOnSugar += price;
                    return amountOfSugarBought;
                case "25":
                    amountOfSugarBought = 25;
                    price = sugar.GetMediumPrice();
                    amountOfSugarBought = playerOne.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    moneySpentOnSugar += price;
                    return amountOfSugarBought;
                case "50":
                    amountOfSugarBought = 50;
                    price = sugar.GetHighPrice();
                    amountOfSugarBought = playerOne.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    moneySpentOnSugar += price;
                    return amountOfSugarBought;
                case "exit":
                    return amountOfSugarBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreSugar();
            }
        }

        public int BuyMoreIce()
        {
            string choice = UserInterface.DisplayBuyMoreIce();
            switch (choice)
            {
                case "100":
                    amountOfIceBought = 100;
                    price = ice.GetLowPrice();
                    amountOfIceBought = playerOne.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    moneySpentOnIce += price;
                    return amountOfIceBought;
                case "250":
                    amountOfIceBought = 250;
                    price = ice.GetMediumPrice();
                    amountOfIceBought = playerOne.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    moneySpentOnIce += price;
                    return amountOfIceBought;
                case "500":
                    amountOfIceBought = 500;
                    price = ice.GetHighPrice();
                    amountOfIceBought = playerOne.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    moneySpentOnIce += price;
                    return amountOfIceBought;
                case "exit":
                    return amountOfIceBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreIce();
            }
        }

        public double GetMoneySpentOnInventory()
        {
            double total = moneySpentOnCups + moneySpentOnLemons + moneySpentOnSugar + moneySpentOnIce;
            return total;
        }
    }
}