using System;
using System.Threading.Tasks;
using beSS.Models.RequestModels;
using beSS.Services;
using Microsoft.AspNetCore.Mvc;

namespace beSS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-product")]
        public IActionResult GetProduct()
        {
            var listProduct = _productService.GetProduct();
            return Ok(listProduct);
        }
        
        [HttpGet("get-product-by-type/{id}")]
        public IActionResult GetProductByType(Guid id)
        {
            var listProduct = _productService.GetProductByType(id);
            return Ok(listProduct);
        }
        
        [HttpGet("get-product-by-category-id/{id}")]
        public IActionResult GetProductBuCategoryID(Guid id)
        {
            var listProduct = _productService.GetProductByCategoryID(id);
            return Ok(listProduct);
        }
        
        [HttpGet("get-brand")]
        public IActionResult GetBrand()
        {
            var listBrand = _productService.Brand();
            return Ok(listBrand);
        }
        
        [HttpGet("get-product-by-brand/{brand}")]
        public IActionResult GetBrand(string brand)
        {
            var listBrand = _productService.GetProductByBrand(brand);
            return Ok(listBrand);
        }
        
        [HttpPost("add-product")]
        public IActionResult AddProduct(CreateProduct request)
        {
            var newProduct = _productService.CreateProduct(request);
            return Ok(newProduct);
        }

        [HttpGet("search-product/{request}")]
        public IActionResult SearchProduct(string request)
        {
            return Ok(_productService.SearchProduct(request));
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            return Ok(_productService.DeleteProduct(id));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateProduct(EditProduct request)
        {
            return Ok(await _productService.Update(request));
        }
    }
}