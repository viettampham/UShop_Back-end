using System;
using System.Collections.Generic;

namespace beSS.Models
{
    public class Category
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}