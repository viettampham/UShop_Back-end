using System;
using System.Collections.Generic;

namespace beSS.Models
{
    public class TypeProduct
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
        public List<Guid> ProductIDs { get; set; }
    }
}