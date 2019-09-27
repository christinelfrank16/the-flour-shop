using System;
using Bakery;
using Bank;
using Interactions;

class Program
{
    static void Main()
    {
        Wallet yourWallet = new Wallet();
        BrickAndMortorBank piggyBank = new BrickAndMortorBank("The Piggy Bank");
        Shop flourShop = new Shop("The Flour Shop");

        Console.WriteLine("Welcome to Baker's Lane! Explore and enjoy your visit!");
        bool stayInBakersLane = true;
        while(stayInBakersLane)
        {
            Console.WriteLine("Where would you like to go? [Bakery, Bank, Market]");
            string[] options = new string[]{"bakery", "bank", "market"};
            string response = Interaction.AskOptionsQuestion(options, "I didn't understand that. Where would you like to go? [Bakery, Bank, Market]");
            Console.WriteLine("");
            if(response == "bakery")
            {
                flourShop.WelcomeMessage();
                Interaction.AddSpace();
                flourShop.ProductsListing();
                bool inShop = true;
                while (inShop)
                {
                    inShop = flourShop.BakeryActions(yourWallet);
                }
                Shop.GoodByeMessage();
            }
            else if(response == "bank")
            {
                piggyBank.Welcome();
                piggyBank.BankAction(yourWallet);
                piggyBank.GoodBye();
            }
            else
            {

            }
        }

        Console.WriteLine("Thanks for visiting Baker's Lane! Hope to see you again soon!");


        
    }


}
