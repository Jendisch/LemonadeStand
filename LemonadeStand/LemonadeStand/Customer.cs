using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        public Customer(Day day, Player playerOne, Random random)
        {

        }
        
        List<double> maxCostCustomerWillPay = new List<double> { 0.25, 0.40, 0.50, 0.75, 1.00, 0.90, 1.25, 1.50, 1.75, 2.0 };
        public double amountWillingToPay;
        List<int> sourPreferenceOptions = new List<int> { 3, 4, 5, 6, 7 }; //Based on number of lemons in each pitcher
        List<int> sweetnessPreferenceOptions = new List<int> { 3, 4, 5, 6, 7 }; //Based on number of cups of sugar in each pitcher
        public int sourPreference;
        public int sweetnessPreference;
        public int willingnessToBuy;
        public bool buy;
        public bool decision;
        public bool customerBuys;

        public bool DetermineIfCustomerBuys(Player playerOne, Day day, Random random)
        {
            FindCustomerPriceLimit(random);
            FindSourPreference(random);
            FindSweetnessPreference(random);
            OddsToBuySourPreference(playerOne);
            OddsToBuySweetnessPreference(playerOne);
            CheckPriceLimit(day);
            WillingnessToBuyOdds();
            customerBuys = DecideIfCustomerWillBuy();
            return customerBuys;
        }

        private double FindCustomerPriceLimit(Random random)
        {
            int amountCustomerWillingToPay = random.Next(0, maxCostCustomerWillPay.Count);
            amountWillingToPay = maxCostCustomerWillPay[amountCustomerWillingToPay];
            return amountWillingToPay;
        }

        private int FindSourPreference(Random random)
        {
            int preference = random.Next(0, sourPreferenceOptions.Count);
            sourPreference = sourPreferenceOptions[preference];
            return sourPreference;
        }

        private int FindSweetnessPreference(Random random)
        {
            int preference = random.Next(0, sweetnessPreferenceOptions.Count);
            sweetnessPreference = sweetnessPreferenceOptions[preference];
            return sweetnessPreference;
        }

        private void OddsToBuySourPreference(Player playerOne)
        {
            if (playerOne.recipe.lemonsUsed >= 5)
            {
                if (sourPreference >= 5)
                {
                    willingnessToBuy += 2;
                }
                else
                {
                    willingnessToBuy -= 1;
                }
            }
            else if (playerOne.recipe.lemonsUsed < 5)
            {
                if (sourPreference < 5)
                {
                    willingnessToBuy += 2;
                }
                else
                {
                    willingnessToBuy -= 1;
                }
            }
        }

        private void OddsToBuySweetnessPreference(Player playerOne)
        {
            if (playerOne.recipe.sugarUsed >= 5)
            {
                if (sweetnessPreference >= 5)
                {
                    willingnessToBuy += 2;
                }
                else
                {
                    willingnessToBuy -= 1;
                }
            }
            else if (playerOne.recipe.sugarUsed < 5)
            {
                if (sweetnessPreference < 5)
                {
                    willingnessToBuy += 2;
                }
                else
                {
                    willingnessToBuy -= 1;
                }
            }
        }

        private bool CheckPriceLimit(Day day)
        {
            if (amountWillingToPay >= day.pricePerCup)
            {
                buy = true;
                return buy;
            }
            else
            {
                buy = false;
                return buy;
            }
        }

        private bool WillingnessToBuyOdds()
        {
            if (willingnessToBuy >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DecideIfCustomerWillBuy()
        {
            decision = WillingnessToBuyOdds();
            if (buy == true && decision == true)
            {
                return true;
            }
            else if (buy == true && decision == false)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}


