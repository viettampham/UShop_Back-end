using System;

namespace beSS.Models.RequestModels
{
    public class CreateOrder
    {
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int QuantityOrder { get; set; }
    }
}