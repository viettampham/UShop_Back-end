using System;
using beSS.Services;
using Microsoft.AspNetCore.Mvc;

namespace beSS.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class TypeProductController:ControllerBase
    {
        private readonly ITypeProductService _typeProductService;

        public TypeProductController(ITypeProductService typeProductService)
        {
            _typeProductService = typeProductService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(_typeProductService.Get());
        }
        [HttpPost("add")]
        public IActionResult Add(string Name)
        {
            return Ok(_typeProductService.Create(Name));
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Guid TypeProductID)
        {
            return Ok(_typeProductService.Delete(TypeProductID));
        }
    }
}