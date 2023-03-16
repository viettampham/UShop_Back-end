using System;
using System.Collections.Generic;

namespace beSS.Models.RequestModels
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int QuantityAvailable { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }

        public List<Guid> CategoryIDs { get; set; }
    }
}