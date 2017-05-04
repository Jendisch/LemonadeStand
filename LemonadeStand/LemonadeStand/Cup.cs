using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Cup : Item
    {

        public override double GetLowPrice()
        {
            lowCost = 1.00;
            return lowCost;

        }

        public override double GetMediumPrice()
        {
            mediumCost = 1.50;
            return mediumCost;
        }

        public override double GetHighPrice()
        {
            highCost = 1.90;
            return highCost;
        }


    }
}
