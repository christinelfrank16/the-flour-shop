using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Bakery
{
    public class Shop
    {
        public Dictionary<string,int> Order { get; set; }
        public Dictionary<Bread, int> MadeBread { get; set; }
        public Dictionary<Pastry, int> MadePastry { get; set; }

        public string Name { get; set; }
        public Shop(string name)
        {
            Name = name;
            Order = new Dictionary<string, int>();
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
            Console.WriteLine("If you don't see something you want, we may be able to make one for you.")
        }

        public void ListBreads()
        {
            Console.WriteLine("Breads: ");
            Console.WriteLine("---------------------------");
            foreach(KeyValuePair<Bread, int> breadPair in MadeBread)
            {
                if(breadPair.Value > 0)
                {
                    Console.WriteLine(" + " + (breadPair.Value) + " - " + (breadPair.Key.IsGlutenFree ? "Gluten free bread " : "Bread ") + "that is " + (breadPair.Key.IsSliced ? "sliced" : "a whole loaf"));
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
                }
            }
            Console.WriteLine("");
        }

        public void AddToOrder(int count, Product product)
        {

        }

        public void MakeFirstProducts(){
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