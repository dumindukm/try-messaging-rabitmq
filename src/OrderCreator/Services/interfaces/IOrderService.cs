using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderCreator.Models;

namespace OrderCreator.Services.interfaces
{
    public interface IOrderService
    {
        Order GetOrder(Guid id);
    }
}