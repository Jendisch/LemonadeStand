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
            lowCost = 21.00;
            return lowCost;

        }

        public override double GetMediumPrice()
        {
            mediumCost = 1.53;
            return mediumCost;
        }

        public override double GetHighPrice()
        {
            highCost = 2.97;
            return highCost;
        }


    }
}
