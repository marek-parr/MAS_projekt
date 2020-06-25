﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Orders
{
    public class Report
    {
        public int Id { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        [Required]
        public DateTime Month { get; set; }

        public double GetSumOfCosts()
        {
            return Orders.Aggregate(0.0, (acc, order) => acc + order.GetCost());
        }
    }
}
