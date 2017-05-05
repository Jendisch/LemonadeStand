using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        
        Player playerOne;
        public Day(Player player)
        {
            playerOne = player;
        }

        public double pricePerCup;
        public double amountOfPotentialCustomers;
        public double potentialCustomers;
        public List<Customer> customers = new List<Customer>();
        public double conditionOdds;
        public int appropriateIceAmount;
        public double dailyProfit;
        public double moneySpentOnInventory;
        public string netProfit;
        public string netDeficit;
        public double totalProfit;
        public int dayNumber;
        public int savedLengthOfGame;

        public void TakeTurn(int lengthOfGame, Day day, Random random, int dayStart = 1)
        {
            moneySpentOnInventory = 0;
            for (var i = dayStart; i <= lengthOfGame; i++)
            {
                dayNumber = i;
                savedLengthOfGame = lengthOfGame;
                Store store = new Store(playerOne);
                Weather weather = new Weather(random);
                weather.GetCurrentForecast(random);
                UserInterface.DisplayCurrentWeather(i, weather);
                weather.GetWeatherForcast(random);
                DisplayInventoryAndMoney();
                GoToStore(store);
                DisplayInventoryAndMoney();
                playerOne.recipe.MakeRecipe();
                playerOne.inventory.RemoveItemsAfterMakingLemonade(playerOne);
                UserInterface.DisplayAmountOfCups(playerOne);
                DecidePriceOfCup();
                GenerateAmountOfPotentialCustomers(weather, random);
                CreateCustomers(day, playerOne, random);
                FindCustomersAndProfit(store);
                totalProfit = (playerOne.wallet.wallet - 30);
                SavedGame saved = new SavedGame(playerOne, dayNumber, savedLengthOfGame, totalProfit);
                saved.AskToSaveGame(playerOne, dayNumber, savedLengthOfGame, totalProfit);
                Console.ReadKey();
            }
        }

        public void GoToStore(Store store)
        {
            string choice = UserInterface.DisplayAskIfGoingToStore();
            if (choice == "yes")
            {
                store.BuyFromStore();
            }
            else if (choice == "no")
            {
                return;
            }
            else
            {
                UserInterface.DisplayNotAValidResponse();
                GoToStore(store);
            }
        }

        public void DisplayInventoryAndMoney()
        {
            playerOne.inventory.ShowItemInventory();
            playerOne.wallet.ShowMoneyAvailable();
        }

        public double DecidePriceOfCup()
        {
            UserInterface.DisplayDecidePriceOfCup();
            try
            {
                pricePerCup = double.Parse(Console.ReadLine());
                return pricePerCup;
            }
            catch (Exception)
            {
                UserInterface.DisplayCatchPriceOfCup();
                DecidePriceOfCup();
                throw;
            }
        }

        public double OddsToBuyTemperature(Weather weather, Random random)
        {
            Console.Clear();
            if (weather.temperature >= 50 && weather.temperature <= 60)
            {
                amountOfPotentialCustomers = random.Next(80, 91);
            }
            else if (weather.temperature > 60 && weather.temperature <= 70)
            {
                amountOfPotentialCustomers = random.Next(91, 100);
            }
            else if (weather.temperature > 70 && weather.temperature <= 80)
            {
                amountOfPotentialCustomers = random.Next(91, 100);
            }
            else if (weather.temperature > 80 && weather.temperature <= 90)
            {
                amountOfPotentialCustomers = random.Next(111, 120);
            }
            else if (weather.temperature > 90 && weather.temperature <= 100)
            {
                amountOfPotentialCustomers = random.Next(101, 110);
            }
            return amountOfPotentialCustomers;
        }

        public double OddsToBuyCondition(Weather weather)
        {
            if (weather.condition == "sunny")
            {
                conditionOdds = 1.0;
            }
            else if (weather.condition == "partly cloudy")
            {
                conditionOdds = 0.95;
            }
            else if (weather.condition == "cloudy")
            {
                conditionOdds = 0.9;
            }
            else if (weather.condition == "overcast" || weather.condition == "foggy")
            {
                conditionOdds = 0.85;
            }
            else if (weather.condition == "rainy")
            {
                conditionOdds = 0.8;
            }
            else if (weather.condition == "thunderstorming")
            {
                conditionOdds = 0.7;
            }
            amountOfPotentialCustomers *= conditionOdds;
            amountOfPotentialCustomers = Math.Ceiling(amountOfPotentialCustomers);
            return amountOfPotentialCustomers;
        }

        public void DecideAppropriateIceAmount(Weather weather)
        {
            if (weather.temperature < 70)
            {
                appropriateIceAmount = 3;
            }
            else if (weather.temperature < 80)
            {
                appropriateIceAmount = 4;
            }
            else if (weather.temperature >= 80)
            {
                appropriateIceAmount = 5;
            }
        }

        public double OddsToBuyIce()
        {
            if ((playerOne.recipe.iceUsed / playerOne.recipe.pitchersUsed) >= appropriateIceAmount)
            {
                return amountOfPotentialCustomers;
            }
            else
            {
                amountOfPotentialCustomers *= 0.8;
                return Math.Ceiling(amountOfPotentialCustomers);
            }
        }


        public double GenerateAmountOfPotentialCustomers(Weather weather, Random random)
        {
            potentialCustomers = OddsToBuyTemperature(weather, random);
            potentialCustomers = OddsToBuyCondition(weather);
            DecideAppropriateIceAmount(weather);
            potentialCustomers = OddsToBuyIce();
            return potentialCustomers;
        }

        public void CreateCustomers(Day day, Player playerOne, Random random)
        {
            customers = new List<Customer>();
            for (int i = 0; i < potentialCustomers; i++)
            {

                Customer customer = new Customer(day, playerOne, random);
                customer.DetermineIfCustomerBuys(playerOne, day, random);
                if(customer.customerBuys == true)
                {
                    customers.Add(customer);
                }
            }
        }

        public void FindCustomersAndProfit(Store store)
        {
            if (customers.Count > playerOne.recipe.cupsUsed)
            {
                dailyProfit = playerOne.recipe.cupsUsed * pricePerCup;
                UserInterface.DisplayNotEnoughLemonadeMade();
                DisplayCustomersAndProfitForNotEnoughLemonadeMade(store, playerOne.recipe.cupsUsed);
            }
            else if (customers.Count <= playerOne.recipe.cupsUsed)
            {
                dailyProfit = customers.Count * pricePerCup;
                DisplayCustomersAndProfit(store);
            }
        }

        public void FindProfitOrDeficit(Store store)
        {
            moneySpentOnInventory = store.GetMoneySpentOnInventory();
            if (dailyProfit >= moneySpentOnInventory)
            {
                double money = dailyProfit - moneySpentOnInventory;
                netProfit = money.ToString("C");
                UserInterface.DisplayNetProfit(netProfit);
            }
            else if (dailyProfit > moneySpentOnInventory)
            {
                double money = moneySpentOnInventory - dailyProfit;
                netDeficit = money.ToString("C");
                UserInterface.DisplayNetDeficit(netDeficit);
            }
        }

        public void DisplayCustomersAndProfit(Store store)
        {
            Console.Clear();
            playerOne.wallet.wallet += dailyProfit;
            string profit = dailyProfit.ToString("C");
            int number = customers.Count;
            UserInterface.DisplayDailyProfitAndWallet(playerOne, profit, number);
            moneySpentOnInventory = store.GetMoneySpentOnInventory();
            FindProfitOrDeficit(store);
        }

        public void DisplayCustomersAndProfitForNotEnoughLemonadeMade(Store store, int number)
        {
            Console.Clear();
            playerOne.wallet.wallet += dailyProfit;
            string profit = dailyProfit.ToString("C");
            number = customers.Count;
            UserInterface.DisplayDailyProfitAndWallet(playerOne, profit, number);
            moneySpentOnInventory = store.GetMoneySpentOnInventory();
            FindProfitOrDeficit(store);
        }
    }
}

