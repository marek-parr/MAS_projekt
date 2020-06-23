using MAS_projekt.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int MyProperty { get; set; }
        public OrderState State { get; set; }
        public DateTime Created { get; set; }
        public DateTime CanceledOrRejected { get; set; }
        public ICollection<Item> Items { get; set; }
        public Client Client { get; set; }

        public double GetCost()
        {
            return Items.Aggregate(0.0, (acc, item) => acc + item.GetPrice());
        }
    }

    public enum OrderState
    {
        CREATED,
        IN_PROGRESS,
        DONE,
        REJECTED,
        CANCELED
    }
}
