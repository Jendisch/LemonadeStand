using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            PreGame preGame = new PreGame(random);
            preGame.ChooseNewOrOldGame(random);


         

        }
    }
}
