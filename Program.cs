using System;
using Bakery;
using Bank;
using Market;
using Interactions;

class Program
{
    static void Main()
    {
        Wallet yourWallet = new Wallet();
        BrickAndMortorBank piggyBank = new BrickAndMortorBank("The Piggy Bank");
        Shop flourShop = new Shop("The Flour Shop");
        MarketStall fireside = new MarketStall("The FireSide");

        Console.WriteLine("Welcome to Baker's Lane! Explore and enjoy your visit!");
        bool stayInBakersLane = true;
        while(stayInBakersLane)
        {
            Console.WriteLine("Where would you like to go? [Bakery, Bank, Market, Leave]");
            string[] options = new string[]{"bakery", "bank", "market", "leave"};
            string response = Interaction.AskOptionsQuestion(options, "I didn't understand that. Where would you like to go? [Bakery, Bank, Market, Leave]");
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
            else if(response == "market")
            {
                fireside.Welcome();
                bool stay = fireside.AskToWork();
                if(stay)
                {
                    fireside.MarketActions(yourWallet);
                    Console.WriteLine("Thanks for helping! Hope to see you again!");
                }
                else
                {
                    Console.WriteLine("Goodness, help is hard to find.. See ya later.");
                }
                
            }
            else 
            {
                stayInBakersLane = false;
            }
        }

        Console.WriteLine("Thanks for visiting Baker's Lane! Hope to see you again soon!");


        
    }


}
