using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Products
{
    public abstract class Computer: Product
    {
        public string Type { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}
