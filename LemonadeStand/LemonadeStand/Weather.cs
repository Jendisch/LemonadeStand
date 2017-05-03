using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public int temperature;
        public string condition;
        public int forecastedTemperature;
        public string forecastedCondition;


        Random random = new Random();

        public string[] weatherTemperature = new string[] { "50-60", "61-70", "71-80", "81-90", "91-100" };
        public string[] weatherCondition = new string[] { "sunny", "partly cloudy", "cloudy", "overcast", "foggy", "rainy" };


        public void GetCurrentForecast()
        {
            GetCurrentTemperature();
            GetCurrentCondition();
        }

        public void GetCurrentTemperature()
        {
            int weatherRandom = random.Next(0, weatherTemperature.Length);
            switch (weatherRandom)
            {
                case 0:
                    temperature = random.Next(50, 61);
                    break;
                case 1:
                    temperature = random.Next(61, 71);
                    break;
                case 2:
                    temperature = random.Next(71, 81);
                    break;
                case 3:
                    temperature = random.Next(81, 91);
                    break;
                case 4:
                    temperature = random.Next(91, 100);
                    break;
                default:
                    break;
            }
        }

        public void GetCurrentCondition()
        {
            int conditionRandom = random.Next(0, weatherCondition.Length);
            condition = weatherCondition[conditionRandom];
        }

        public void GetWeatherForcast()
        {
            Console.WriteLine("Would you like to see the weather forcast for tomorrow? Please type 'yes' or 'no'.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "yes":
                    FindOneDayForecast();
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Not a valid response. Please type one of the options below.");
                    GetWeatherForcast();
                    break;
            }
        }
        
        private void FindOneDayForecast()
        {
            Console.Clear();
            forecastedTemperature = random.Next(50, 101);
            int conditionRandom = random.Next(0, weatherCondition.Length);
            forecastedCondition = weatherCondition[conditionRandom];
            Console.WriteLine("Your forecasted weather for tomorrow is " + forecastedTemperature + " degrees and " + forecastedCondition + ".");
            Console.WriteLine("Please hit any key to continue.");
            Console.ReadKey();
        }


    }
}
