using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon : Item
    {

        public override double GetLowPrice()
        {
            lowCost = 0.58;
            return lowCost;

        }

        public override double GetMediumPrice()
        {
            mediumCost = 2.20;
            return mediumCost;
        }

        public override double GetHighPrice()
        {
            highCost = 4.38;
            return highCost;
        }


    }
}
