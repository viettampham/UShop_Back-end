using System;
using System.Collections.Generic;

namespace beSS.Models.ViewModels
{
    public class ProductResponse
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int QuantityAvailable { get; set; }
        public int Price { get; set; }
        public string DisplayPrice { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public List<Guid> CategoryIDs { get; set; }

        public List<Category> Categorys { get; set; }
    }
}