﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.Models.Products
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Category Supercategory { get; set; }
        public int? SupercategoryId { get; set; }
        public ICollection<Category> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
