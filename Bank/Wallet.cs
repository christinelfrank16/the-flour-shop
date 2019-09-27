using System;

namespace Bank{
    public class Wallet
    {
        public double Cash { get; set; }
        public Wallet()
        {
            Cash = 25.00;
        }

        public bool AddCash(double amount)
        {
            bool isSuccessful = false;
            if(amount > 0)
            {
                Cash += amount;
                isSuccessful = true;
            }
            return isSuccessful;
        }

        public bool RemoveCash(double amount)
        {
            bool isSuccessful = false;
            if(amount > 0 && Cash - amount >= 0)
            {
                Cash -= amount;
                isSuccessful = true;
            }
            else
            {
                Console.WriteLine("You don't have enough cash to do that.");
            }
            return isSuccessful;
        }

        public double CheckCash()
        {
            return Cash;
        }

    }
}