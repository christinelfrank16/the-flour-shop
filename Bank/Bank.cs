using System;
using Interactions;

namespace Bank
{
    public class BrickAndMortorBank
    {
        public String Name { get; set; }
        public double Account { get; set; }

        public BrickAndMortorBank(string name)
        {
            Name = name;
            Account = 50.00;
        }

        public void Welcome()
        {
            Console.WriteLine("Hello, and welcome to " + Name + ".");
        }

        public void GoodBye()
        {
            Console.WriteLine("Good-bye! Hope you have a good rest of your day!");
        }

        public void DisplayMoney(Wallet wallet)
        {
            Console.WriteLine("Your Account value is: $" + Account.ToString());
            Console.WriteLine("Your wallet has: $" + wallet.Cash.ToString());
        }

        public Wallet BankAction(Wallet wallet)
        {
            string[] options = new string[]{"withdraw", "deposit", "leave"};
            DisplayMoney(wallet);
            Console.WriteLine("What would you like to do? [Withdraw, Deposit, Leave]");
            string response = Interaction.AskOptionsQuestion(options, "What was that again? What would you like to do? [Withdraw, Deposit, Leave]");
            if(response == "withdraw" || response == "deposit")
            {
                Console.WriteLine("How much would you like to " + response + "?");
                double value = Interaction.AskPositiveDoubleQuestion("Come again? How much would you like to " + response + "?");

                if(response == "withdraw")
                {
                    Withdraw(value);
                    wallet.AddCash(value);
                }
                else
                {
                    if(wallet.RemoveCash(value))
                    {
                        Deposit(value);
                    }
                }

                Interaction.AddSpace();
                Console.WriteLine("Current values: ");
                DisplayMoney(wallet);

                Console.WriteLine("");
            }

            return wallet;
        }

        public double Withdraw(double amount)
        {
            double valueReceived = 0;
            if(amount <= Account && amount > 0)
            {
                Account -= amount;
                valueReceived = amount;
            }
            else if(amount > 0)
            {
                Console.WriteLine("You can not withdraw a negative amount. Sorry.");
            }
            else
            {
                Console.WriteLine("Sorry, you don't have that much money in your account.");
                Console.WriteLine("I suggest you earn some money at the market.");
            }
            return valueReceived;
        }

        public void Deposit(double amount)
        {
            if(amount >= 0)
            {
                Account += amount;
            }
            else
            {
                Console.WriteLine("Who are you trying to fool?!");
            }
        }

    }
}