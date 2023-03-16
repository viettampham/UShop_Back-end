using System;
using System.Collections.Generic;

namespace beSS.Models.ViewModels
{
    public class OrderResponse
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int QuantityAvailable { get; set; }
        public int Price { get; set; }
        public string DisplayPrice { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }

        public List<Category> Categories { get; set; }
        public int QuantityOrder { get; set; }
        public int TotalMoney { get; set; }
        public string DisplayTotalMoney { get; set; }
        public bool IsinBill{ get; set; }
        public Guid BillID { get; set; }
    }
}