using MAS_projekt.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.People
{
    public class Client
    {
        public long Id { get; set; }
        public Address PreferredAddress { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        [Required]
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public ICollection<Order> Orders { get; set; }

        [NotMapped]
        public string ClientNumberAndFullName
        {
            get { return $"{Id} - " + Person.GetFullName(); }
        }
        [NotMapped]
        public string FullName
        {
            get { return Person.GetFullName(); }
        }

        public Client()
        {

        }

        public Client(Person person)
        {
            this.Person = person;
            this.PersonId = person.Id;
            this.PreferredAddress = this.Person.Address;
            this.ShoppingCart = new ShoppingCart
            {
                Client = this
            };
        }

        public override string ToString()
        {
            return ClientNumberAndFullName;
        }
    }
}
