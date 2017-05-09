using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {

        public Weather(Random random)
        {
            
        }

        public int temperature;
        public string condition;
        public int forecastedTemperature;
        public string forecastedCondition;

        

        public string[] weatherTemperature = new string[] { "50-60", "61-70", "71-80", "81-90", "91-100" };
        public string[] weatherCondition = new string[] { "sunny", "partly cloudy", "cloudy", "overcast", "foggy", "rainy", "thunderstorming" };

        
        public void GetCurrentForecast(Random random)
        {
            Console.Clear();
            GetCurrentTemperature(random);
            GetCurrentCondition(random);
        }

        private void GetCurrentTemperature(Random random)
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

        private void GetCurrentCondition(Random random)
        {
            int conditionRandom = random.Next(0, weatherCondition.Length);
            condition = weatherCondition[conditionRandom];
        }

        public void GetWeatherForcast(Random random)
        {
            string choice = UserInterface.AskToSeeTomorrowForecast();
            switch (choice)
            {
                case "yes":
                    FindOneDayForecast(random);
                    break;
                case "no":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    GetWeatherForcast(random);
                    break;
            }
        }
        
        private void FindOneDayForecast(Random random)
        {
            Console.Clear();
            forecastedTemperature = random.Next(50, 101);
            int conditionRandom = random.Next(0, weatherCondition.Length);
            forecastedCondition = weatherCondition[conditionRandom];
            UserInterface.DisplayTomorrowForecast(forecastedTemperature, forecastedCondition);
        }
    }
}
