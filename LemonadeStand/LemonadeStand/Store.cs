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


        public void BuyFromStore()
        {
            Console.Clear();
            Console.WriteLine("Would you like to buy more 'cups', 'lemons', 'sugar', or 'ice'? Choose one. If you don't need anymore supplies to make lemonade type 'exit' to leave the store.");
            string choice = Console.ReadLine().ToLower();
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
                    Console.WriteLine("Not a valid response. Please type one of the options below.");
                    BuyFromStore();
                    break;
            }
        }

        public int BuyMoreCups()
        {
            Console.WriteLine("Cups are sold in groups. 25 cups for $0.93. 50 cups for $1.53. 100 cups for $2.97. How many cups would you like to buy? If you would rather not buy cups, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "25":
                    amountOfCupsBought = 25;
                    price = cup.GetLowPrice();
                    amountOfCupsBought = playerOne.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    return amountOfCupsBought;
                case "50":
                    amountOfCupsBought = 50;
                    price = cup.GetMediumPrice();
                    amountOfCupsBought = playerOne.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    return amountOfCupsBought;
                case "100":
                    amountOfCupsBought = 100;
                    price = cup.GetHighPrice();
                    amountOfCupsBought = playerOne.wallet.CheckIfBrokeForCups(price, amountOfCupsBought);
                    return amountOfCupsBought;
                case "exit":
                    return amountOfCupsBought;
                default:
                    Console.WriteLine("Not a valid response. Please type one of the options below.");
                    BuyMoreCups();
                    return amountOfCupsBought;
            }

        }

        public int BuyMoreLemons()
        {
            Console.WriteLine("Lemons are sold in groups. 10 lemons for $0.58. 30 lemons for $2.20. 75 lemons for $4.38. How many lemons would you like to buy? If you would rather not buy lemons, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "10":
                    amountOfLemonsBought = 10;
                    price = lemon.GetLowPrice();
                    amountOfLemonsBought = playerOne.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    return amountOfLemonsBought;
                case "30":
                    amountOfLemonsBought = 30;
                    price = lemon.GetMediumPrice();
                    amountOfLemonsBought = playerOne.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    return amountOfLemonsBought;
                case "75":
                    amountOfLemonsBought = 75;
                    price = lemon.GetHighPrice();
                    amountOfLemonsBought = playerOne.wallet.CheckIfBrokeForLemons(price, amountOfLemonsBought);
                    return amountOfLemonsBought;
                case "exit":
                    return amountOfLemonsBought;
                default:
                    Console.WriteLine("Not a valid response. Please type one of the options below.");
                    BuyMoreLemons();
                    return amountOfLemonsBought;
            }

        }

        public int BuyMoreSugar()
        {
            Console.WriteLine("Sugar is sold in groups of cups. 8 cups for $0.66. 20 cups for $1.55. 48 cups for $3.30. How many cups of sugar would you like to buy? If you would rather not buy any sugar, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "8":
                    amountOfSugarBought = 8;
                    price = sugar.GetLowPrice();
                    amountOfSugarBought = playerOne.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    return amountOfSugarBought;
                case "20":
                    amountOfSugarBought = 20;
                    price = sugar.GetMediumPrice();
                    amountOfSugarBought = playerOne.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    return amountOfSugarBought;
                case "48":
                    amountOfSugarBought = 48;
                    price = sugar.GetHighPrice();
                    amountOfSugarBought = playerOne.wallet.CheckIfBrokeForSugar(price, amountOfSugarBought);
                    return amountOfSugarBought;
                case "exit":
                    return amountOfSugarBought;
                default:
                    Console.WriteLine("Not a valid response. Please type a number of one of the options below.");
                    BuyMoreLemons();
                    return amountOfSugarBought;
            }
        }

        public int BuyMoreIce()
        {
            Console.WriteLine("Ice is sold in groups of ice cubes. 100 cubes for $0.98. 250 cubes for $2.10. 500 cubes for $3.80. How many ice cubes would you like to buy? If you would rather not buy ice, type 'exit' to return to the store.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "100":
                    amountOfIceBought = 100;
                    price = ice.GetLowPrice();
                    amountOfIceBought = playerOne.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    return amountOfIceBought;
                case "250":
                    amountOfIceBought = 250;
                    price = ice.GetMediumPrice();
                    amountOfIceBought = playerOne.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    return amountOfIceBought;
                case "500":
                    amountOfIceBought = 500;
                    price = ice.GetHighPrice();
                    amountOfIceBought = playerOne.wallet.CheckIfBrokeForIce(price, amountOfIceBought);
                    return amountOfIceBought;
                case "exit":
                    return amountOfIceBought;
                default:
                    Console.WriteLine("Not a valid response. Please type a number of one of the options below.");
                    BuyMoreLemons();
                    return amountOfIceBought;
            }

        }

    }
}
