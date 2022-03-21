using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderCreator.Models;
using OrderCreator.Services.interfaces;

namespace OrderCreator.Services.concrete
{
    public class OrderService : IOrderService
    {
        public Order GetOrder(Guid id)
        {
            return new Order(){Qty=1, ItemCode="A1001"};
        }
    }
}