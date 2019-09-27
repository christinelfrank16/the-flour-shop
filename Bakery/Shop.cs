using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Interactions;

namespace Bakery
{
    public class Shop
    {
        public Dictionary<Product,int> Order { get; set; }
        public Dictionary<Bread, int> MadeBread { get; set; }
        public Dictionary<Pastry, int> MadePastry { get; set; }

        public string Name { get; set; }
        public Shop(string name)
        {
            Name = name;
            Order = new Dictionary<Product, int>();
            MakeFirstProducts();
        }

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to "+ Name + "!");
        }



        public void ProductsListing()
        {
            Console.WriteLine("Here is a list of our products: ");
            ListBreads();
            ListPastries();
            Console.WriteLine("If you don't see something you want, we may be able to make one for you.");
        }

        public void ListBreads()
        {
            Console.WriteLine("Breads: ");
            Console.WriteLine("---------------------------");
            foreach(KeyValuePair<Bread, int> breadPair in MadeBread)
            {
                if(breadPair.Value > 0)
                {
                    Console.WriteLine(" + Qty " + (breadPair.Value) + " - " + (breadPair.Key.IsGlutenFree ? "Gluten free bread " : "Bread ") + "that is " + (breadPair.Key.IsSliced ? "sliced" : "a whole loaf"));
                    Console.WriteLine("Price: $" + breadPair.Key.DefaultCost.ToString() + " each");
                }
            }
            Console.WriteLine("");
        }

        public void ListPastries()
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            Console.WriteLine("Pastries: ");
            Console.WriteLine("---------------------------");
            foreach (KeyValuePair<Pastry, int> pastryPair in MadePastry)
            {
                if (pastryPair.Value > 0)
                {
                    Console.WriteLine(" + " + (pastryPair.Value) + " - " + (pastryPair.Key.IsSavory ? "Savory " : "Sweet ") + "pastry in the shape of a" + (vowels.Contains(pastryPair.Key.Shape[0]) ? "n " + pastryPair.Key.Shape : " " + pastryPair.Key.Shape));
                    Console.WriteLine("Price: $" + pastryPair.Key.DefaultCost.ToString() + " each");
                }
            }
            Console.WriteLine("");
        }

        public void RequestProduct()
        {
            string[] productOptions = new string[]{"bread", "pastry", "nevermind"};
            Console.WriteLine("What would you like to order? [Bread, Pastry, Nevermind]");
            string product = Interaction.AskOptionsQuestion(productOptions, "So.. What would you like to order?  [Bread, Pastry, Nevermind]");
            if(product.StartsWith('b'))
            {
                bool[] breadRequest = RequestBread();
                int breadCount = IsBreadMade(breadRequest);
                int[] breadToMake = ProductQuantity(breadCount);
                if (breadToMake[0] > 0)
                {
                    Console.WriteLine("Your bread just went in the oven! Please wait. It's worth it!");
                    MakeBread(breadRequest[0], breadRequest[1], breadToMake[0]);
                }
                Bread breadEx = new Bread(breadRequest[0], breadRequest[1]);
                AddToOrder(breadEx, breadToMake[1]);
                RemoveFromShopInventory(breadEx, breadToMake[1]);
            }
            else if(product.StartsWith('p'))
            {
                string[] pastryRequest = RequestPastry();
                int pastryCount = IsPastryMade(Convert.ToBoolean(pastryRequest[0]),pastryRequest[1]);
                int[] pastryToMake = ProductQuantity(pastryCount);
                if(pastryToMake[0] > 0)
                {
                    Console.WriteLine("Your " + (pastryToMake[0] == 1 ? "pastry" : "pastries") + " just went in the oven! Please wait. It's worth it!");
                    MakePastry(Convert.ToBoolean(pastryRequest[0]), pastryRequest[1], pastryToMake[0]);
                }
                Pastry pastryEx = new Pastry(Convert.ToBoolean(pastryRequest[0]), pastryRequest[1]);
                AddToOrder(pastryEx, pastryToMake[1]);
                RemoveFromShopInventory(pastryEx, pastryToMake[1]);
            }
            else if(product.StartsWith('n'))
            {
                Console.WriteLine("Ok.");
            }
        }

        public int[] ProductQuantity(int existingCount)
        {
            int countToMake = 0;
            Console.WriteLine("How many would you like to order?");
            int count = Interaction.AskPositiveIntQuestion("I didn't understand that. How many would you like?");
            if(existingCount > 0 && count > existingCount)
            {
                Console.WriteLine("We don't have that many. Would you accept " + existingCount + " instead? [Y/N]");
                bool orderExisting = Interaction.AskYesNoQuestion("Please let me know. Would you accept " + existingCount + " instead? [Y/N]");
                if(orderExisting)
                {
                    Console.WriteLine("Thank you for being so flexible!");
                }
                else
                {
                    Console.WriteLine("Ok, no worries! We can make " + (count - existingCount).ToString() + " more for you!");
                    countToMake = count - existingCount;
                }
            }
            else if (existingCount == 0)
            {
                countToMake = count;
            }
            else if(count == 0)
            {
                Console.WriteLine("Oh, you don't want it anymore? What a shame...");
                countToMake = -1;
            }
            int[] quantity = new int[]{countToMake, count};
            return quantity;
        }

        public bool[] RequestBread()
        {
            Console.WriteLine("Ahh, our breads are the finest around!");
            Console.WriteLine("Would you like your bread gluten free? [Y/N]");

            bool isGlutenFree = Interaction.AskYesNoQuestion("Sorry, I didn't get that. Would you like your bread gluten free? [Y/N]");
            
            Console.WriteLine("Would you like your bread sliced? [Y/N]");

            bool isSliced = Interaction.AskYesNoQuestion("Sorry, I didn't get that. Would you like your bread sliced? [Y/N]");
            
            bool[] requestedBread = new bool[] {isGlutenFree, isSliced};
            return requestedBread;
        }

        public string[] RequestPastry()
        {
            Console.WriteLine("Fabulous! We have excellent pastries!");
            Console.WriteLine("Would you like a savory pastry? [Y/N]");
            bool isSavory = Interaction.AskYesNoQuestion("Sorry, I didn't get that. Would you like your pastry to be savory? [Y/N]");

            string[] shapes = new string[]{"circle", "flower", "star", "oblong", "square"};
            Console.WriteLine("What shape would you like? Our options are: " + shapes.ToString());
            string shape = Interaction.AskOptionsQuestion(shapes, "Ach, it's loud in here. What shape would you like, again? Our options are: " + shapes.ToString());
            string[] requestedPastry = new string[]{isSavory.ToString(), shape};
            return requestedPastry;
        }


        public int IsBreadMade(bool[] breadOptions)
        {
            int breadCount = 0;
            Bread breadInList = MadeBread.Where(breadPair => breadPair.Key.IsGlutenFree == breadOptions[0] && breadPair.Key.IsSliced == breadOptions[1]).FirstOrDefault().Key;
            if(breadInList != null)
            {
                breadCount = MadeBread[breadInList];
            }
            return breadCount;
        }

        public int IsPastryMade(bool isSavory, string shape)
        {
            int pastryCount = 0;
            Pastry pastryInList = MadePastry.Where(pastryPair => pastryPair.Key.IsSavory == isSavory && pastryPair.Key.Shape == shape).FirstOrDefault().Key;
            if(pastryInList != null)
            {
                pastryCount = MadePastry[pastryInList];
            }
            return pastryCount;
        }
        public void AddToOrder(Product product, int count)
        {
            Product inOrder = Order.Where(orderPair => orderPair.Key == product).FirstOrDefault().Key;
            if(inOrder != null)
            {
                Order[product] += count;
            }
            else
            {
                Order.Add(product, count);
            }
        }

        public void RemoveFromShopInventory(Product product, int count)
        {
            if(product.Type == "Bread")
            {
                Bread breadProduct = (Bread) product;
                Bread bread = MadeBread.Where(breadPair => breadPair.Key.IsGlutenFree == breadProduct.IsGlutenFree && breadPair.Key.IsSliced == breadProduct.IsSliced).FirstOrDefault().Key;
                MadeBread[bread] -= count;
            }
            else
            {
                Pastry pastryProduct = (Pastry) product;
                Pastry pastry = MadePastry.Where(pastryPair => pastryPair.Key.IsSavory == pastryProduct.IsSavory && pastryPair.Key.Shape == pastryProduct.Shape).FirstOrDefault().Key;
                MadePastry[pastry] -= count;
            }
        }

        
        private void MakeFirstProducts(){
            Bread startBread = new Bread(false, false);
            MadeBread = new Dictionary<Bread, int>();
            MadeBread.Add(startBread, 2);
            Pastry startPastry = new Pastry(false, "flower");
            MadePastry = new Dictionary<Pastry, int>();
            MadePastry.Add(startPastry, 5);
        }
        public void MakeBread(bool glutenFree, bool isSliced, int count)
        {
            Bread bread = new Bread(glutenFree, isSliced);
            Thread.Sleep(500); // baking time
            if (isSliced)
            {
                Thread.Sleep(200 * count); // slice time
            }
            Bread breadInList = MadeBread.Where(breadPair => breadPair.Key.IsSliced == isSliced && breadPair.Key.IsGlutenFree == glutenFree).FirstOrDefault().Key;
            if(breadInList != null)
            {
                MadeBread[breadInList] += count;
            }
            else
            {
                MadeBread.Add(bread,count);
            }
        }

        public void MakePastry(bool isSavory, string shape, int count)
        {
            Pastry pastry = new Pastry(isSavory, shape);
            Thread.Sleep(300); // baking time
            Pastry pastryInList = MadePastry.Where(pastryPair => pastryPair.Key.IsSavory == isSavory && pastryPair.Key.Shape == shape).FirstOrDefault().Key;
            if (pastryInList != null)
            {
                MadePastry[pastryInList] += count;
            }
            else
            {
                MadePastry.Add(pastry, count);
            }
        }
    }
}