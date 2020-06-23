using MAS_projekt.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.People
{
    public class Client
    {
        public string ClientNumber { get; set; }
        public Address PreferredAddress { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
