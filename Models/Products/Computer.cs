using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Products
{
    public abstract class Computer : Product
    {
        [Required]
        public string Type { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

    }
}
