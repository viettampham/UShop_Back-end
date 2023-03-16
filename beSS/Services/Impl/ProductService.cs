using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace beSS.Services.Impl
{
    public class ProductService:IProductService
    {
        private readonly MasterDbContext _context;

        public ProductService(MasterDbContext context)
        {
            _context = context;
        }

        public List<string> Brand()// 1 2 3 2 8 8 3 4 4 5 1
        {
            var listBrand = _context.Products
                .Select(p => p.Brand).ToList();
            for (int i = 0; i < listBrand.Count; i++)
            {
                for (int j = i+1; j < listBrand.Count; j++)
                {
                    if (listBrand[i] == listBrand[j])
                    {
                        listBrand.Remove(listBrand[j]);
                    }
                }
            }
            return listBrand;
        }

        public List<ProductResponse> GetProduct()
        {
            var listProduct = _context.Products
                .Select(p => new ProductResponse()
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    QuantityAvailable = p.QuantityAvailable,
                    Price = p.Price,
                    DisplayPrice = p.Price.ToString("#,## VNĐ"),
                    Size = p.Size,
                    Brand = p.Brand,
                    CategoryIDs = p.CategoryIDs,
                    Categorys = p.Categories
                }).ToList();
            return listProduct;
        }

        public List<ProductResponse> GetProductByBrand(string brand)
        {
            var listProduct = _context.Products
                .Where(p => p.Brand.ToLower() == brand.ToLower())
                .Select(p => new ProductResponse()
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    QuantityAvailable = p.QuantityAvailable,
                    Price = p.Price,
                    DisplayPrice = p.Price.ToString("#,## VNĐ"),
                    Size = p.Size,
                    Brand = p.Brand,
                    Categorys = p.Categories
                }).ToList();
            return listProduct;
        }

        public List<ProductResponse> GetProductByCategoryID(Guid id)
        {
            var listProduct = _context.Products
                .Where(x=>x.CategoryIDs.Contains(id))
                .Select(p => new ProductResponse()
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Description = p.Description,
                ImageURL = p.ImageURL,
                QuantityAvailable = p.QuantityAvailable,
                Price = p.Price,
                DisplayPrice = p.Price.ToString("#,## VNĐ"),
                Size = p.Size,
                Brand = p.Brand,
                Categorys = p.Categories
            }).ToList();
            return listProduct;
        }

        public MessageResponse CreateProduct(CreateProduct request)
        {
            var listCategory = new List<Category>();
            request.CategoryIDs.ForEach(id =>
            {
                var targetCategory = _context.Categories
                    .FirstOrDefault(c => c.CategoryID == id);
                if (targetCategory == null)
                {
                    throw new Exception("not found this category");
                }
                listCategory.Add(targetCategory);
            });
            var newProduct = new Product()
            {
                ProductID = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                ImageURL = request.ImageURL,
                QuantityAvailable = request.QuantityAvailable,
                Price = request.Price,
                Size = request.Size,
                Brand = request.Brand,
                CategoryIDs = request.CategoryIDs,
                Categories = listCategory
            };
            _context.Add(newProduct);
            _context.SaveChanges();

            return new MessageResponse()
            {
                Status = 200,
                Message = "Success"
            };
        }

        public MessageResponse DeleteProduct(Guid id)
        {
            var targetProduct = _context.Products.FirstOrDefault(p => p.ProductID == id);
            _context.Remove(targetProduct);
            _context.SaveChanges();
            if (targetProduct == null)
            {
                return new MessageResponse()
                {
                    Status = 404,
                    Message = "Not found thí product in database"
                };
            }
            return new MessageResponse()
            {
                Status = 200,
                Message = "Xóa thành công"
            };
        }

        public List<ProductResponse> SearchProduct(string request)
        {
            var listProduct = _context.Products
                .Where(p => p.Brand.ToLower() == request.ToLower() || p.Name.ToLower().Contains(request.ToLower()))
                .Select(p => new ProductResponse()
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    QuantityAvailable = p.QuantityAvailable,
                    Price = p.Price,
                    DisplayPrice = p.Price.ToString("#,## VND"),
                    Size = p.Size,
                    Brand = p.Brand,
                    Categorys = p.Categories
                }).ToList();
            return listProduct;
        }

        public async Task<ProductResponse> Update(EditProduct request)
        {
            var targetProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductID == request.ProductID);
            if (targetProduct == null)
            {
                throw new Exception("Không tìm thấy sản phẩm");
            }

            var listCategory = new List<Category>();
            foreach (var id in request.CategorieIDs)
            {
                var targetCategory = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryID == id);
                if (targetCategory == null)
                {
                    throw new Exception("Không tìm thấy category");
                }
                listCategory.Add(targetCategory);
            }

            targetProduct.Name = request.Name;
            targetProduct.Description = request.Description;
            targetProduct.ImageURL = request.ImageURL;
            targetProduct.QuantityAvailable = request.QuantityAvailable;
            targetProduct.Price = request.Price;
            targetProduct.Size = request.Size;
            targetProduct.Brand = request.Brand;
            targetProduct.CategoryIDs = request.CategorieIDs;
            
            await _context.SaveChangesAsync();
            return new ProductResponse()
            {
                ProductID = targetProduct.ProductID,
                Name = targetProduct.Name,
                Description = targetProduct.Description,
                ImageURL = targetProduct.ImageURL,
                QuantityAvailable = targetProduct.QuantityAvailable,
                Price = targetProduct.Price,
                Brand = targetProduct.Brand,
                Categorys = listCategory
            };
        }
    }
}