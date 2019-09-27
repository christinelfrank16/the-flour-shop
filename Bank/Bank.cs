using System;

namespace Bank
{
    public class Bank
    {
        public String Name { get; set; }
        public double Account { get; set; }

        public Bank(string name)
        {
            Name = name;
            Account = 100.00;
        }

        public double Withdraw(double amount)
        {
            double valueReceived = 0;
            if(amount <= Account)
            {
                Account -= amount;
                valueReceived = amount;
            }
            else
            {
                Console.WriteLine("Sorry, you don't have that much money in your account.");
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
                Console.WriteLine("Who are you trying to fool?! Try again.");
            }
        }

    }
}