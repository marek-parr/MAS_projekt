using MAS_projekt.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class Item
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }

        public double GetPrice()
        {
            return Amount * Product.Price;
        }
    }
}
