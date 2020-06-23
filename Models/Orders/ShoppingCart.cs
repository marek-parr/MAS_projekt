using MAS_projekt.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public ICollection<Item> Items { get; set; }
        public Client Client { get; set; }
    }
}
