using System;

namespace Bakery
{
    public class Product
    {
        public string Type { get; set; }
        public double DefaultCost { get; set; }
        public int[] Sale { get; set; }
        public Product(string type, double defaultCost)
        {
            Type = type;
            DefaultCost = defaultCost;
            Sale = new int[3]; // buyCount, getCount, totalSaleCost
        }
    }

    public class Bread : Product{
        public bool IsGlutenFree { get; set; }
        public bool IsSliced { get; set; }

        public Bread(bool glutenFree, bool isSliced):base("Bread", 2.00){
            IsGlutenFree = glutenFree;
            IsSliced = isSliced;
        }
    }

    public class Pastry : Product
    {
        public bool IsSavory { get; set; }
        public string Shape { get; set; }
        public Pastry(bool isSavory, string shape) : base("Pastry", 1.00)
        {
            IsSavory = isSavory;
            Shape = shape;
        }
    }
}