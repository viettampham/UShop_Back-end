using System;
using beSS.Models.RequestModels;
using beSS.Services;
using Microsoft.AspNetCore.Mvc;

namespace beSS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController:ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet("admin-get-bill")]
        public IActionResult GetAll()
        {
            return Ok(_billService.GetAll());
        }
        
        [HttpGet("user-get-bill-no-payed/{id}")]
        public IActionResult GetBillNoPayedByUser(Guid id)
        {
            return Ok(_billService.GetAllBillNoPayedByUser(id));
        }
        
        [HttpGet("user-get-bill-payed/{id}")]
        public IActionResult GetBillPayedByUser(Guid id)
        {
            return Ok(_billService.GetAllBillPayedByUser(id));
        }

        [HttpPost("create-bill")]
        public IActionResult CreateBill(CreateBillRequest request)
        {
            return Ok(_billService.CreateBill(request));
        }

        [HttpDelete("delete-bill/{id}")]
        public IActionResult DeleteBill(Guid id)
        {
            return Ok(_billService.DeleteBill(id));
        }

        [HttpPost("confirm-bill/{id}")]
        public IActionResult ConfirmBill(Guid id)
        {
            return Ok(_billService.ConFirmBill(id));
        }

        [HttpGet("search-bill-by-name/{CustomerName}")]
        public IActionResult SearchBillByName(string CustomerName)
        {
            return Ok(_billService.SearchBillByName(CustomerName));
        }
        
        [HttpGet("search-bill-by-id/{id}")]
        public IActionResult GetBillByID(Guid id)
        {
            return Ok(_billService.GetBillById(id));
        }
    }
}