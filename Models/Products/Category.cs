using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Products
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Supercategory { get; set; }
        public virtual ICollection<Category> Subcategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
