using System;
using System.Collections.Generic;
using System.Linq;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace beSS.Services.Impl
{
    public class OrderService:IOrderService
    {
        private readonly MasterDbContext _context;

        public OrderService(MasterDbContext context)
        {
            _context = context;
        }
        public List<OrderResponse> GetOrder()
        {
            var listOrder = _context.Orders.Select(o => new OrderResponse()
            {
                OrderID = o.OrderID,
                UserID = o.UserID,
                ProductID = o.Product.ProductID,
                Name = o.Product.Name,
                Description = o.Product.Description,
                ImageURL = o.Product.ImageURL,
                QuantityAvailable = o.Product.QuantityAvailable,
                Price = o.Product.Price,
                DisplayPrice = o.Product.Price.ToString("#,## VND"),
                Size = o.Product.Size,
                Brand = o.Product.Brand,
                Categories = o.Product.Categories,
                QuantityOrder = o.QuantityOrder,
                TotalMoney = o.TotalMoney,
                DisplayTotalMoney = o.TotalMoney.ToString("#,## VND"),
                IsinBill = o.IsinBill
            }).ToList();
            return listOrder;
        }

        public List<OrderResponse> GetOrderByUser(Guid id)
        {
            var listOrder = _context.Orders
                .Where(o=>o.UserID == id && o.IsinBill == false)
                .Select(o => new OrderResponse()
            {
                OrderID = o.OrderID,
                UserID = o.UserID,
                ProductID = o.Product.ProductID,
                Name = o.Product.Name,
                Description = o.Product.Description,
                ImageURL = o.Product.ImageURL,
                QuantityAvailable = o.Product.QuantityAvailable,
                Price = o.Product.Price,
                DisplayPrice = o.Product.Price.ToString("#,## VND"),
                Size = o.Product.Size,
                Brand = o.Product.Brand,
                Categories = o.Product.Categories,
                QuantityOrder = o.QuantityOrder,
                TotalMoney = o.TotalMoney,
                DisplayTotalMoney = o.TotalMoney.ToString("#,## VND"),
                IsinBill = o.IsinBill
            }).ToList();
            return listOrder;
        }

        public OrderResponse CreateOrder(CreateOrder request)
        {
            if (request.QuantityOrder <= 0 )
            {
                throw new Exception("quantity Order > 0");
            }

            var checkOrder = _context.Orders
                .Include(o=>o.Product)
                .FirstOrDefault(o => o.UserID == request.UserID && o.Product.ProductID == request.ProductID && o.IsinBill == false);
            
            if (checkOrder != null)
            {
                checkOrder.QuantityOrder = checkOrder.QuantityOrder + request.QuantityOrder;
                checkOrder.TotalMoney = checkOrder.TotalMoney + request.QuantityOrder * checkOrder.Product.Price;
                _context.SaveChanges();
                return new OrderResponse()
                {
                    OrderID = checkOrder.OrderID,
                    UserID = checkOrder.UserID,
                    ProductID = checkOrder.Product.ProductID,
                    Name = checkOrder.Product.Name,
                    Description = checkOrder.Product.Description,
                    ImageURL = checkOrder.Product.ImageURL,
                    QuantityAvailable = checkOrder.Product.QuantityAvailable,
                    Price = checkOrder.Product.Price,
                    DisplayPrice = checkOrder.Product.Price.ToString("#,## VND"),
                    Size = checkOrder.Product.Size,
                    Brand = checkOrder.Product.Brand,
                    Categories = checkOrder.Product.Categories,
                    QuantityOrder = checkOrder.QuantityOrder,
                    TotalMoney = checkOrder.TotalMoney,
                    DisplayTotalMoney = checkOrder.TotalMoney.ToString("#,## VND"),
                    IsinBill = checkOrder.IsinBill,
                    BillID = checkOrder.IDOB
                };
            }
            
            var newOrder = new Order()
            {
                OrderID = Guid.NewGuid(),
                UserID = request.UserID,
                Product = _context.Products
                    .FirstOrDefault(p => p.ProductID == request.ProductID),
                QuantityOrder = request.QuantityOrder,
                TotalMoney = request.QuantityOrder * _context.Products
                    .FirstOrDefault(p => p.ProductID == request.ProductID)!.Price,
                IsinBill = false,
                IDOB = Guid.Empty
            };
            _context.Add(newOrder);
            _context.SaveChanges();
            return new OrderResponse()
            {
                OrderID = newOrder.OrderID,
                UserID = newOrder.UserID,
                ProductID = newOrder.Product.ProductID,
                Name = newOrder.Product.Name,
                Description = newOrder.Product.Description,
                ImageURL = newOrder.Product.ImageURL,
                QuantityAvailable = newOrder.Product.QuantityAvailable,
                Price = newOrder.Product.Price,
                DisplayPrice = newOrder.Product.Price.ToString("#,## VND"),
                Size = newOrder.Product.Size,
                Brand = newOrder.Product.Brand,
                Categories = newOrder.Product.Categories,
                QuantityOrder = newOrder.QuantityOrder,
                TotalMoney = newOrder.TotalMoney,
                DisplayTotalMoney = newOrder.TotalMoney.ToString("#,## VND"),
                IsinBill = newOrder.IsinBill,
                BillID = newOrder.IDOB
            };
        }

        public OrderResponse EditOrder(EditOrder request)
        {
            throw new NotImplementedException();
        }

        public MessageResponse DeleteOrder(Guid id)
        {
            var targetOrder = _context.Orders.FirstOrDefault(o => o.OrderID == id);
            _context.Remove(targetOrder);
            _context.SaveChanges();
            return new MessageResponse()
            {
                Status = 200,
                Message = "Xóa thành công"
            };
        }
    }
}