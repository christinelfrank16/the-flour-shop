using System;
using System.Collections.Generic;
using Bank;

namespace Market
{
    public class MarketStall
    {
        public string Name { get; set; }
        public Dictionary<ItemToSell, int> ItemsForSale { get; set; }

        public MarketStall(string name)
        {
            Name = name;
        }

        private Dictionary<ItemToSell, int> InitalItems()
        {
            Dictionary<ItemToSell, int> initialItems = new Dictionary<ItemToSell, int>();
            ItemToSell lamp = new ItemToSell("Lamp", 8.00);
            ItemToSell chair = new ItemToSell("Comfy Chair", 10.50 );
            ItemToSell book = new ItemToSell("The Gauntlet by King George II", 3.00);
            ItemToSell whiskey = new ItemToSell("Wasted Wiskey", 20.00);
            return initialItems;
        }

        
    }

    public class ItemToSell
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ItemToSell(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}