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
                inShop = flourShop.Checkout();
            }
            else if (toDo == "leave")
            {
                inShop = flourShop.LeaveShop();
            }

        }
        Shop.GoodByeMessage();
    }
}
