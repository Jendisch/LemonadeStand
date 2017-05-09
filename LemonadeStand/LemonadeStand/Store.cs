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
        Player playerTwo;

        public Store(Player player)
        {
            playerOne = player;
        }

        public Store(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
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

        private int BuyMoreCups()
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

        private int BuyMoreLemons()
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

        private int BuyMoreSugar()
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

        private int BuyMoreIce()
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

        public void BuyFromStorePlayerTwo()
        {
            string choice = UserInterface.DisplayAskToBuyItems();
            switch (choice)
            {
                case "cups":
                    playerTwo.inventory.AddCups(BuyMoreCupsPlayerTwo());
                    BuyFromStorePlayerTwo();
                    break;
                case "lemons":
                    playerTwo.inventory.AddLemons(BuyMoreLemonsPlayerTwo());
                    BuyFromStorePlayerTwo();
                    break;
                case "sugar":
                    playerTwo.inventory.AddSugar(BuyMoreSugarPlayerTwo());
                    BuyFromStorePlayerTwo();
                    break;
                case "ice":
                    playerTwo.inventory.AddIce(BuyMoreIcePlayerTwo());
                    BuyFromStorePlayerTwo();
                    break;
                case "exit":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    BuyFromStorePlayerTwo();
                    break;
            }
        }

        private int BuyMoreCupsPlayerTwo()
        {
            string choice = UserInterface.DisplayBuyMoreCups();
            switch (choice)
            {
                case "25":
                    amountOfCupsBought = 25;
                    price = cup.GetLowPrice();
                    amountOfCupsBought = playerTwo.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    moneySpentOnCups += price;
                    return amountOfCupsBought;
                case "50":
                    amountOfCupsBought = 50;
                    price = cup.GetMediumPrice();
                    amountOfCupsBought = playerTwo.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    moneySpentOnCups += price;
                    return amountOfCupsBought;
                case "100":
                    amountOfCupsBought = 100;
                    price = cup.GetHighPrice();
                    amountOfCupsBought = playerTwo.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    moneySpentOnCups += price;
                    return amountOfCupsBought;
                case "exit":
                    return amountOfCupsBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreCupsPlayerTwo();
            }
        }

        private int BuyMoreLemonsPlayerTwo()
        {
            string choice = UserInterface.DisplayBuyMoreLemons();
            switch (choice)
            {
                case "10":
                    amountOfLemonsBought = 10;
                    price = lemon.GetLowPrice();
                    amountOfLemonsBought = playerTwo.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    moneySpentOnLemons += price;
                    return amountOfLemonsBought;
                case "50":
                    amountOfLemonsBought = 50;
                    price = lemon.GetMediumPrice();
                    amountOfLemonsBought = playerTwo.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    moneySpentOnLemons += price;
                    return amountOfLemonsBought;
                case "75":
                    amountOfLemonsBought = 75;
                    price = lemon.GetHighPrice();
                    amountOfLemonsBought = playerTwo.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    moneySpentOnLemons += price;
                    return amountOfLemonsBought;
                case "exit":
                    return amountOfLemonsBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreLemonsPlayerTwo();
            }
        }

        private int BuyMoreSugarPlayerTwo()
        {
            string choice = UserInterface.DisplayBuyMoreSugar();
            switch (choice)
            {
                case "10":
                    amountOfSugarBought = 10;
                    price = sugar.GetLowPrice();
                    amountOfSugarBought = playerTwo.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    moneySpentOnSugar += price;
                    return amountOfSugarBought;
                case "25":
                    amountOfSugarBought = 25;
                    price = sugar.GetMediumPrice();
                    amountOfSugarBought = playerTwo.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    moneySpentOnSugar += price;
                    return amountOfSugarBought;
                case "50":
                    amountOfSugarBought = 50;
                    price = sugar.GetHighPrice();
                    amountOfSugarBought = playerTwo.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    moneySpentOnSugar += price;
                    return amountOfSugarBought;
                case "exit":
                    return amountOfSugarBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreSugarPlayerTwo();
            }
        }

        private int BuyMoreIcePlayerTwo()
        {
            string choice = UserInterface.DisplayBuyMoreIce();
            switch (choice)
            {
                case "100":
                    amountOfIceBought = 100;
                    price = ice.GetLowPrice();
                    amountOfIceBought = playerTwo.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    moneySpentOnIce += price;
                    return amountOfIceBought;
                case "250":
                    amountOfIceBought = 250;
                    price = ice.GetMediumPrice();
                    amountOfIceBought = playerTwo.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    moneySpentOnIce += price;
                    return amountOfIceBought;
                case "500":
                    amountOfIceBought = 500;
                    price = ice.GetHighPrice();
                    amountOfIceBought = playerTwo.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    moneySpentOnIce += price;
                    return amountOfIceBought;
                case "exit":
                    return amountOfIceBought;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    return BuyMoreIcePlayerTwo();
            }
        }
    }
}