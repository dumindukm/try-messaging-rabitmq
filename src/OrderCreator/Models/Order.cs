using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderCreator.Models
{
    public class Order
    {
        public Order()
        {
            Id= Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int Qty { get; set; } = 0;
        public string ItemCode { get; set; } ="";
    }
}