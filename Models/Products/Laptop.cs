using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Products
{
    public class Laptop : Computer
    {
        public int MaximumBatteryLife { get; set; }
        public double DisplaySize { get; set; }
    }
}
