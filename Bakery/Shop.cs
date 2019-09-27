using System;
using System.Collections.Generic;

namespace Bakery
{
    public class Shop
    {
        Dictionary<string,int> Order { get; set; }
        public Shop()
        {
            Order = new Dictionary<string, int>();
        }
    }
}