using MAS_projekt.Models.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
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
        [NotMapped]
        public string CreatedDateString
        { 
            get { return Created.Date.ToShortDateString(); }
        }
        [NotMapped]
        public string StateString
        {
            get { return State.GetOrderStateDisplayName(); }
        }
        [NotMapped]
        public double Cost
        {
            get { return Items.Aggregate(0.0, (acc, item) => acc + item.Price); }
        }
    }

    public enum OrderState
    {
        [Display(Name = "Utworzone")]
        CREATED,
        [Display(Name = "W toku")]
        IN_PROGRESS,
        [Display(Name = "Zrealizowane")]
        DONE,
        [Display(Name = "Odrzucone")]
        REJECTED,
        [Display(Name = "Anulowane")]
        CANCELED
    }

    public static class OrderStateExtensions
    {
        public static string GetOrderStateDisplayName(this OrderState orderState)
        {
            return orderState.GetType().GetMember(orderState.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }
    }
}
