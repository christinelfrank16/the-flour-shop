using System;
using System.Linq;
using System.Collections.Generic;
using Bakery;
using Interactions;

class Program
{
    static void Main()
    {
        Shop flourShop = new Shop("The Flour Shop");
        flourShop.WelcomeMessage();
        Interaction.AddSpace();
        flourShop.ProductsListing();
        bool inShop = true;
        while(inShop){
            Interaction.AddSpace();
            string toDo = Interaction.UserInput();
            if(toDo == "order")
            {
                flourShop.RequestProduct();
            }
            else if (toDo == "show")
            {
                flourShop.ProductsListing();
            }
            else if (toDo == "checkout")
            {
                flourShop.DisplayOrder();
                Console.WriteLine("Would you like to continue checking out? [Y/N]");
                bool contWithOrder = Interaction.AskYesNoQuestion("Can you say that again? Would you like to continue checking out? [Y/N]");
                if(contWithOrder)
                {
                    foreach(KeyValuePair<Product, int> orderpair in flourShop.Order)
                    {
                        flourShop.RemoveFromShopInventory(orderpair.Key, orderpair.Value);
                    }
                    inShop = false;
                }
            }
            else if (toDo == "leave")
            {
                Console.WriteLine("Are you sure you want to leave? Your order will be cleared if you do. [Y/N]");
                bool contToLeave = Interaction.AskYesNoQuestion("I didn't get your answer... Are you sure you want to leave? Your order will be cleared if you do. [Y/N]");
                if(contToLeave)
                {
                    inShop = false;
                    flourShop.Order = new Dictionary<Product, int>();
                }
            }

        }
        Shop.GoodByeMessage();
    }
}