using System;
using System.Collections.Generic;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;

namespace beSS.Services
{
    public interface IBillService
    {
        List<BillResponse> GetAll();
        BillResponse GetBillById(Guid id);
        List<BillResponse> SearchBillByName(string CustomerName);
        List<BillResponse> GetAllBillNoPayedByUser(Guid id);
        List<BillResponse> GetAllBillPayedByUser(Guid id);
        MessageResponse CreateBill(CreateBillRequest request);
        MessageResponse DeleteBill(Guid id);
        MessageResponse ConFirmBill(Guid id);
    }
}