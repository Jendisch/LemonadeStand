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
            Game game = new Game();
            game.StartGame(random);
        }
    }
}
