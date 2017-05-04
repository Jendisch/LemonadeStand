using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        
        public string playerName;
        public Inventory inventory = new Inventory();
        public Wallet wallet = new Wallet();
        public Recipe recipe;

        public Player()
        {
            recipe = new Recipe(inventory);
        }

        public Player(string playerName, Inventory inventory, Wallet wallet)
        {
            this.playerName = playerName;
            this.inventory = inventory;
            this.wallet = wallet;
            recipe = new Recipe(inventory);
        }
    }
}
