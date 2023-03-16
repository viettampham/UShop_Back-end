using System;

namespace beSS.Models.RequestModels
{
    public class CreateBillRequest
    {
        public Guid UserID { get; set; }
        public string AddressTranfer { get; set; }
        public string AddressDetail { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneNumber { get; set; }
    }
}