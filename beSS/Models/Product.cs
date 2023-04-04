using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace beSS.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }

        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int QuantityAvailable { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public Guid TypeProductID { get; set; }
        public List<Guid> CategoryIDs { get; set; }
        public List<Category> Categories { get; set; }
    }
}