using MAS_projekt.Models.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public long OrderNumber { get; set; }
        [Required]
        public OrderState State { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? CanceledOrRejected { get; set; }
        public ICollection<Item> Items { get; set; }
        [Required]
        public Client Client { get; set; }
        public long ClientId { get; set; }

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
