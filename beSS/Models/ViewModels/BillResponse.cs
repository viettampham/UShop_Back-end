using System;
using System.Collections.Generic;
using System.Globalization;

namespace beSS.Models.ViewModels
{
    public class BillResponse
    {
        public Guid BillID { get; set; }
        public Guid UserID { get; set; }
        public string DateCreated{ get; set; }
        
        public List<OrderResponse> Orders { get; set; }
        public int TotalBill { get; set; }
        public string DisplayTotalBill { get; set; }
        public string AddressTranfer { get; set; }
        public string AddressDetail { get; set; }
        public string NameCustomer { get; set; }
        public string FullNameUser { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPayed { get; set; }
    }
}