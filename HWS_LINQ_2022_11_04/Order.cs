using System;
using System.Collections.Generic;
using System.Linq;
namespace HWS_LINQ_2022_11_04
{
    public class Order
    {
        public int Price { get; set; }
        //ctor
        public Order()
        {
            Price = new Random().Next(50,1000);
        }
    }
}
