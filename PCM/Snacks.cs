using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM
{
    public class Snacks : Item
    {
        string IconDestination;

        public Snacks(string name,int quantity,int price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
