using System.Collections.Generic;

namespace beSS.Models.ViewModels
{
    public class RevenueMonth
    {
        public int Month { get; set; }
        public RevenueResponse RevenueResponse { get; set; }
        public List<BillResponse> BillResponses { get; set; }
    }
}