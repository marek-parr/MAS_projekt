using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.People
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfDismissal { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public Person Person { get; set; }
        public int PersonId { get; set; }

        public TimeSpan GetSeniority()
        {
            if (IsActive)
            {
                return DateTime.Now.Subtract(DateOfEmployment);
            } else
            {
                return DateOfDismissal.Subtract(DateOfEmployment);
            }
        }

        public Employee()
        {
            this.DateOfEmployment = DateTime.Now;
        }

        public Employee(Person person, double salary)
        {
            this.Person = person;
            this.Salary = salary;
            this.DateOfEmployment = DateTime.Now;
            this.IsActive = true;
        }
    }
}
