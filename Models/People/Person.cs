using MAS_projekt.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.People
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public virtual Client Client { get; set; }
        public Employee Employee { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void AddClient(Client client)
        {
            this.Client = client;
        }

        public void AddEmployee(Employee employee)
        {
            this.Employee = employee;
        }

        public Person()
        {

        }

        public Person(string firstName, string lastName, DateTime dateOfBirth,
            string phoneNumber, string email, Address address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
        }
    }
}
