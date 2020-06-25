using MAS_projekt.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public double GetPrice()
        {
            return Amount * Product.Price;
        }
    }
}
