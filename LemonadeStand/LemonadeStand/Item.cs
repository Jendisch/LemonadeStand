using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Item
    {

        public int numberOfItems = 0;
        public double lowCost;
        public double mediumCost;
        public double highCost;


        public abstract double GetLowPrice();

        public abstract double GetMediumPrice();

        public abstract double GetHighPrice();

    }
}
