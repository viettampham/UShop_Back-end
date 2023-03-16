using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace beSS.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public Product Product { get; set; }
        public int QuantityOrder { get; set; }
        public int TotalMoney { get; set; }
        public bool IsinBill { get; set; }
        public Guid IDOB { get; set; }
    }
}