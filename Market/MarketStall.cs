using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bank;
using Interactions;

namespace Market
{
    public class MarketStall
    {
        public string Name { get; set; }
        public Dictionary<ItemToSell, int> ItemsForSale { get; set; }

        public MarketStall(string name)
        {
            Name = name;
            ItemsForSale = InitalItems();
        }

        public void Welcome()
        {
            Console.WriteLine("Hello there! Welcome to " + Name);
        }

        public bool AskToWork()
        {
            Console.WriteLine("We are hiring for help. If you accept, you get a cut of each item you sell.");
            Console.WriteLine("Do you want to work for " + Name + "? [Y/N]");
            bool response = Interaction.AskYesNoQuestion("Hey! I asked a question! Do you want to work for " + Name + " or not? [Y/N]");
            
            return response;
        }

        public void MarketActions(Wallet wallet)
        {
            Interaction.AddSpace();
            Console.WriteLine("Here, take the front desk and sell to customers.");
            bool keepGoing = true;
            while(keepGoing)
            {
                Random rnd = new Random();
                int customerInterest = rnd.Next(0,10);
                Thread.Sleep(200 * customerInterest);
                SaleInteraction(wallet);
                Thread.Sleep(300);
                Interaction.AddSpace();
                Console.WriteLine("Want to keep selling things? [Y/N]");
                keepGoing = Interaction.AskYesNoQuestion("Sooo.... Do you want to keep selling things? [Y/N]");
            }
        }

        public void SaleInteraction(Wallet wallet)
        {
            ItemToSell itemSold = InterestedCustomer();
            if(itemSold != null)
            {
                SellItem(itemSold, wallet);
            }
        }

        public ItemToSell InterestedCustomer()
        {
            ItemToSell soldItem = null;
            bool successfulSale = false;
            ItemToSell item = null;
            Random rnd = new Random();
            int index = rnd.Next(0, ItemsForSale.Count);
            while(item == null)
            {
                item = ItemsForSale.ElementAtOrDefault(index).Key;
                if(ItemsForSale[item] <= 0){
                    item = null;
                }
                index = rnd.Next(0, ItemsForSale.Count);
            }
            Console.WriteLine("** A Potential New Customer Approaches **");
            Console.WriteLine("Hey! That thing.. Umm.. The " + item.Name + ". Is it for sale? [Y/N]");
            bool forSale = Interaction.AskYesNoQuestion("I didn't catch that. Is the " + item.Name + " for sale? [Y/N]");
            if(forSale)
            {
                successfulSale = ConvinceCustomer();
            }
            else
            {
                Console.WriteLine("Oh... I guess I'll just go then...");
            }

            if(successfulSale)
            {
                soldItem = item;
            }
            return soldItem;
        }

        public bool ConvinceCustomer()
        {
            bool isSuccessful = false;
            string[] convinceMes = {"Oh, I looked closer and it doesn't look that good..", "Is it used? It looks used...", "Hmmm, I don't know..."};
            string[] convinced = {"Oh, ok. I guess so. I'll take it!", "I think you're right. I'll buy it!", "I suppose I can settle for that."};
            Random rnd = new Random();
            int index = rnd.Next(0, convinceMes.Length);

            Console.WriteLine(convinceMes[index]);
            string response = Console.ReadLine().ToLower();
            if(response == "" || response.Contains("..") || response.Contains("leave"))
            {
                Console.WriteLine("Wow, you're an awful salesperson. I'm going somewhere else.");
            }
            else if(rnd.Next(0,100) % 3 == 0)
            {
                Console.WriteLine("Actually, I don't think I want it. Thanks anyway.");
            }
            else
            {
                int indexSuccess = rnd.Next(0, convinced.Length);
                Console.WriteLine(convinced[indexSuccess]);
                isSuccessful = true;
            }
            return isSuccessful;
        }

        public void SellItem(ItemToSell item, Wallet wallet)
        {
            Random rnd = new Random();
            int ratio = rnd.Next(50,80);

            Console.WriteLine("Congrats, you sold " + item.Name + " for " + item.Price.ToString() + "!");
            Console.WriteLine("This time, I'll let you have " + ratio.ToString() + "% of the cut.");
            
            double earnings = item.Price*0.50*((double)ratio/100);
            Console.WriteLine("You receive $" + earnings.ToString() + ".");
            wallet.AddCash(earnings);
            RemoveItem(item);
        }

        public void RemoveItem(ItemToSell item)
        {
            ItemsForSale[item]--;
        }

        private Dictionary<ItemToSell, int> InitalItems()
        {
            Dictionary<ItemToSell, int> initialItems = new Dictionary<ItemToSell, int>();
            ItemToSell lamp = new ItemToSell("Lamp", 8.00);
            ItemToSell chair = new ItemToSell("Comfy Chair", 10.50 );
            ItemToSell book = new ItemToSell("The Gauntlet by King George II", 3.00);
            ItemToSell whiskey = new ItemToSell("Wasted Wiskey", 20.00);
            ItemToSell rug = new ItemToSell("Soft Rug", 6.00);

            initialItems.Add(lamp, 2);
            initialItems.Add(chair, 1);
            initialItems.Add(book, 1);
            initialItems.Add(whiskey, 3);
            initialItems.Add(rug, 3);

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