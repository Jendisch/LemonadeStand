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
        Player playerTwo;

        public Day(Player player)
        {
            playerOne = player;
        }

        public Day(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
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
        public double totalProfitPlayerOne;
        public double totalProfitPlayerTwo;
        public int dayNumber;
        public int savedLengthOfGame;

        public void TakeTurnOnePlayer(int lengthOfGame, Day day, Random random, int dayStart = 1)
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
                DisplayInventoryAndMoneyPlayerOne();
                GoToStore(store);
                DisplayInventoryAndMoneyPlayerOne();
                playerOne.recipe.MakeRecipe();
                playerOne.inventory.RemoveItemsAfterMakingLemonade(playerOne);
                UserInterface.DisplayAmountOfCupsPlayerOne(playerOne);
                DecidePriceOfCup();
                GenerateAmountOfPotentialCustomers(weather, random);
                CreateCustomers(day, playerOne, random);
                FindCustomersAndProfitPlayerOne(store);
                totalProfitPlayerOne = (playerOne.wallet.wallet - 30);
                SavedGame saved = new SavedGame(playerOne, dayNumber, savedLengthOfGame, totalProfitPlayerOne);
                saved.AskToSaveGame(playerOne, dayNumber, savedLengthOfGame, totalProfitPlayerOne);
                Console.ReadKey();
            }
        }

        public void TakeTurnTwoPlayers(int lengthOfGame, Day day, Random random, int dayStart = 1)
        {
            moneySpentOnInventory = 0;
            for (var i = dayStart; i <= lengthOfGame; i++)
            {
                dayNumber = i;
                savedLengthOfGame = lengthOfGame;
                Store store = new Store(playerOne, playerTwo);
                Weather weather = new Weather(random);
                weather.GetCurrentForecast(random);
                UserInterface.DisplayCurrentWeather(i, weather);
                weather.GetWeatherForcast(random);
                UserInterface.DisplayPlayerOneTurn(playerOne);
                DisplayInventoryAndMoneyPlayerOne();
                GoToStore(store);
                DisplayInventoryAndMoneyPlayerOne();
                playerOne.recipe.MakeRecipe();
                playerOne.inventory.RemoveItemsAfterMakingLemonade(playerOne);
                UserInterface.DisplayAmountOfCupsPlayerOne(playerOne);
                DecidePriceOfCup();
                GenerateAmountOfPotentialCustomers(weather, random);
                CreateCustomers(day, playerOne, random);
                FindCustomersAndProfitPlayerOne(store);
                totalProfitPlayerOne = (playerOne.wallet.wallet - 30);
                SavedGame saved = new SavedGame(playerOne, dayNumber, savedLengthOfGame, totalProfitPlayerOne);
                saved.AskToSaveGame(playerOne, dayNumber, savedLengthOfGame, totalProfitPlayerOne);

                UserInterface.DisplayPlayerTwoTurn(playerTwo);
                DisplayInventoryAndMoneyPlayerTwo();
                GoToStorePlayerTwo(store);
                DisplayInventoryAndMoneyPlayerTwo();
                playerTwo.recipe.MakeRecipe();
                playerTwo.inventory.RemoveItemsAfterMakingLemonadePlayerTwo(playerTwo);
                UserInterface.DisplayAmountOfCupsPlayerTwo(playerTwo);
                DecidePriceOfCup();
                GenerateAmountOfPotentialCustomers(weather, random);
                CreateCustomers(day, playerTwo, random);
                FindCustomersAndProfitPlayerTwo(store);
                totalProfitPlayerTwo = (playerTwo.wallet.wallet - 30);
                SavedGame save = new SavedGame(playerTwo, dayNumber, savedLengthOfGame, totalProfitPlayerTwo);
                save.AskToSaveGame(playerTwo, dayNumber, savedLengthOfGame, totalProfitPlayerTwo);
                Console.ReadKey();
            }
        }

        private void GoToStore(Store store)
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

        private void GoToStorePlayerTwo(Store store)
        {
            string choice = UserInterface.DisplayAskIfGoingToStore();
            if (choice == "yes")
            {
                store.BuyFromStorePlayerTwo();
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

        private void DisplayInventoryAndMoneyPlayerOne()
        {
            playerOne.inventory.ShowItemInventoryPlayerOne(playerOne);
            playerOne.wallet.ShowMoneyAvailable();
        }

        private void DisplayInventoryAndMoneyPlayerTwo()
        {
            playerTwo.inventory.ShowItemInventoryPlayerTwo(playerTwo);
            playerTwo.wallet.ShowMoneyAvailable();
        }

        private double DecidePriceOfCup()
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

        private double OddsToBuyTemperature(Weather weather, Random random)
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

        private double OddsToBuyCondition(Weather weather)
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

        private void DecideAppropriateIceAmount(Weather weather)
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

        private double OddsToBuyIce()
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


        private double GenerateAmountOfPotentialCustomers(Weather weather, Random random)
        {
            potentialCustomers = OddsToBuyTemperature(weather, random);
            potentialCustomers = OddsToBuyCondition(weather);
            DecideAppropriateIceAmount(weather);
            potentialCustomers = OddsToBuyIce();
            return potentialCustomers;
        }

        private void CreateCustomers(Day day, Player playerOne, Random random)
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

        private void FindCustomersAndProfitPlayerOne(Store store)
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

        private void FindCustomersAndProfitPlayerTwo(Store store)
        {
            if (customers.Count > playerTwo.recipe.cupsUsed)
            {
                dailyProfit = playerTwo.recipe.cupsUsed * pricePerCup;
                UserInterface.DisplayNotEnoughLemonadeMade();
                DisplayCustomersAndProfitForNotEnoughLemonadeMadePlayerTwo(store, playerTwo.recipe.cupsUsed);
            }
            else if (customers.Count <= playerTwo.recipe.cupsUsed)
            {
                dailyProfit = customers.Count * pricePerCup;
                DisplayCustomersAndProfitPlayerTwo(store);
            }
        }

        private void FindProfitOrDeficit(Store store)
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

        private void DisplayCustomersAndProfit(Store store)
        {
            Console.Clear();
            playerOne.wallet.wallet += dailyProfit;
            string profit = dailyProfit.ToString("C");
            int number = customers.Count;
            UserInterface.DisplayDailyProfitAndWallet(playerOne, profit, number);
            moneySpentOnInventory = store.GetMoneySpentOnInventory();
            FindProfitOrDeficit(store);
        }

        private void DisplayCustomersAndProfitPlayerTwo(Store store)
        {
            Console.Clear();
            playerTwo.wallet.wallet += dailyProfit;
            string profit = dailyProfit.ToString("C");
            int number = customers.Count;
            UserInterface.DisplayDailyProfitAndWallet(playerTwo, profit, number);
            moneySpentOnInventory = store.GetMoneySpentOnInventory();
            FindProfitOrDeficit(store);
        }

        private void DisplayCustomersAndProfitForNotEnoughLemonadeMade(Store store, int number)
        {
            Console.Clear();
            playerOne.wallet.wallet += dailyProfit;
            string profit = dailyProfit.ToString("C");
            number = customers.Count;
            UserInterface.DisplayDailyProfitAndWallet(playerOne, profit, number);
            moneySpentOnInventory = store.GetMoneySpentOnInventory();
            FindProfitOrDeficit(store);
        }

        private void DisplayCustomersAndProfitForNotEnoughLemonadeMadePlayerTwo(Store store, int number)
        {
            Console.Clear();
            playerTwo.wallet.wallet += dailyProfit;
            string profit = dailyProfit.ToString("C");
            number = customers.Count;
            UserInterface.DisplayDailyProfitAndWallet(playerTwo, profit, number);
            moneySpentOnInventory = store.GetMoneySpentOnInventory();
            FindProfitOrDeficit(store);
        }
    }
}

