using System;
using System.Collections.Generic;
using System.Linq;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;

namespace beSS.Services.Impl
{
    public class CategoryService:ICategoryService
    {
        private readonly MasterDbContext _context;

        public CategoryService(MasterDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategory()
        {
            var listCategory = _context.Categories
                .Select(c => new Category()
                {
                    CategoryID = c.CategoryID,
                    Name = c.Name,
                    Products = c.Products
                }).ToList();
            return listCategory;
        }

        public Category CreateCategory(CreateCategory request)
        {
            var newCategory = new Category()
            {
                CategoryID = Guid.NewGuid(),
                Name = request.Name,
            };
            _context.Add(newCategory);
            _context.SaveChanges();
            return newCategory;
        }

        public Category EditCategory(EditCategory request)
        {
            var taretCategory = _context.Categories.FirstOrDefault(c => c.CategoryID == request.CategoryID);
            if (taretCategory == null)
            {
                throw new Exception("not found");
            }

            taretCategory.Name = request.Name;
            _context.SaveChanges();
            return taretCategory;
        }

        public MessageResponse DeleteCategory(Guid id)
        {
            var taretCategory = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (taretCategory != null)
            {
                _context.Remove(taretCategory);
                _context.SaveChanges();
                return new MessageResponse()
                {
                    Status = 200,
                    Message = "Success"
                };
            }

            return new MessageResponse()
            {
                Status = 200,
                Message = "Not found this category"
            };
        }
    }
}