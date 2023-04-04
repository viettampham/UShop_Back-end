using System;
using System.Collections.Generic;

namespace beSS.Models
{
    public class Bill
    {
        public Guid BillID { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Order> Orders { get; set; }
        public int TotalBill { get; set; }
        public string AddressTranfer { get; set; }
        public string AddressDetail { get; set; }
        public string NameCustomer { get; set; }
        public string FullNameUser { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPayed { get; set; }
        public List<Guid> OrderIDs { get; set; }
    }
}