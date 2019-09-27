using System;

namespace Bakery
{
    public class Product
    {
        public string Type { get; set; }
        public double Cost { get; set; }
        public Product(string type, double cost)
        {
            Type = type;
            Cost = cost;
        }
    }

    public class Bread : Product{
        public Bread():base("Bread", 2.00){

        }
    }

    public class Pastry : Product
    {
        public Pastry() : base("Pastry", 1.00)
        {

        }
    }
}