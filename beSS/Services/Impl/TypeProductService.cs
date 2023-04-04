using System;
using System.Collections.Generic;
using System.Linq;
using beSS.Models;
using beSS.Models.ViewModels;

namespace beSS.Services.Impl
{
    public class TypeProductService:ITypeProductService
    {
        private readonly MasterDbContext _context;

        public TypeProductService(MasterDbContext context)
        {
            _context = context;
        }
        public List<TypeProduct> Get()
        {
            var listType = _context.TypeProducts.Select(x => x).ToList();
            return listType;
        }

        public TypeProduct Create(string Name)
        {
            var newType = new TypeProduct()
            {
                ID = Guid.NewGuid(),
                Name = Name
            };
            _context.Add(newType);
            _context.SaveChanges();
            return newType;
        }

        public MessageResponse Delete(Guid TypeProductID)
        {
            var targetType = _context.TypeProducts.FirstOrDefault(x => x.ID == TypeProductID);
            if (targetType == null)
            {
                return new MessageResponse()
                {
                    Status = 404,
                    Message = "Not found"
                };
            }

            _context.Remove(targetType);
            _context.SaveChanges();
            return new MessageResponse()
            {
                Status = 200,
                Message = "Xóa thành công"
            };
        }
    }
}