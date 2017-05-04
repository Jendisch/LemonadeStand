using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Sugar : Item
    {

        public override double GetLowPrice()
        {
            lowCost = 0.50;
            return lowCost;

        }

        public override double GetMediumPrice()
        {
            mediumCost = 1.75;
            return mediumCost;
        }

        public override double GetHighPrice()
        {
            highCost = 3.50;
            return highCost;
        }


    }
}
