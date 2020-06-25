using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class WrongOrderStateException: Exception
    {
        public WrongOrderStateException()
        {

        }

        public WrongOrderStateException(Order order, OrderState state)
            : base($"Order state should be {state}, but is {order.State}")
        {

        }

        public WrongOrderStateException(Order order)
            : base($"Order state cannot be {order.State}")
        {

        }
    }
}
