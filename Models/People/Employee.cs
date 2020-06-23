using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models
{
    public class Employee
    {
        public double Salary { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfDismissal { get; set; }
        public bool IsActive { get; set; }

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
    }
}
