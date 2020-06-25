using MAS_projekt.Models.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        [Required]
        public Client Client { get; set; }
        public long ClientId { get; set; }
    }
}
