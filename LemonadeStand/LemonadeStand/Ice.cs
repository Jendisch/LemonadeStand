using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Ice : Item
    {

        public override double GetLowPrice()
        {
            lowCost = 1.00;
            return lowCost;

        }

        public override double GetMediumPrice()
        {
            mediumCost = 2.25;
            return mediumCost;
        }

        public override double GetHighPrice()
        {
            highCost = 4.00;
            return highCost;
        }


    }
}
