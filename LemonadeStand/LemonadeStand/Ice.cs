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
            lowCost = 0.98;
            return lowCost;

        }

        public override double GetMediumPrice()
        {
            mediumCost = 2.10;
            return mediumCost;
        }

        public override double GetHighPrice()
        {
            highCost = 3.80;
            return highCost;
        }


    }
}
