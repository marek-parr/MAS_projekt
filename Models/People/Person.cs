using MAS_projekt.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.People
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void AddClient(string clientNumber)
        {
            Client client = new Client
            {
                ClientNumber = clientNumber,
                PreferredAddress = this.Address
            };
            this.Client = client;
        }

        public void AddEmployee(int salary)
        {
            Employee employee = new Employee
            {
                Salary = salary,
                DateOfEmployment = DateTime.Now
            };
            this.Employee = employee;
        }
    }
}
