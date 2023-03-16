/*using System;
using System.Collections.Generic;
using System.Linq;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace beSS.Services.Impl
{
    public class CartService:ICartService
    {
        private readonly MasterDbContext _context;

        public CartService(MasterDbContext context)
        {
            _context = context;
        }
        public CartResponse GetCartByUser(Guid id)
        {
            /*var cartResponse = _context.Carts
                .Include(c=>c.Orders)
                .FirstOrDefault(c => c.UserID == id);
            if (cartResponse == null)
            {
                throw new Exception("not found cart");
            }

            var listOrderResponse = _context.Orders
                .Include(o => o.Product)
                .Where(o => o.UserID == cartResponse.UserID)
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
                    Size = o.Product.Size,
                    Brand = o.Product.Brand,
                    Categories = o.Product.Categories,
                    TotalMoney = o.TotalMoney
                }).ToList();#1#
            var cartResponse = _context.Carts
                .FirstOrDefault(c => c.UserID == id && c.IsinBill == false);
            if (cartResponse == null)
            {
                throw new Exception("not found this cart");
            }
            return new CartResponse()
            {
                CartID = cartResponse.CartID,
                UserID = cartResponse.UserID,
                Orders = _context.Orders
                    .Include(o=>o.Product)
                    .Where(o=>o.UserID == cartResponse.UserID)
                    .Select(o=>new OrderResponse()
                    {
                        OrderID = o.OrderID,
                        UserID = o.UserID,
                        ProductID = o.Product.ProductID,
                        Name = o.Product.Name,
                        Description = o.Product.Description,
                        ImageURL = o.Product.ImageURL,
                        QuantityAvailable = o.Product.QuantityAvailable,
                        Price = o.Product.Price,
                        Size = o.Product.Size,
                        Brand = o.Product.Brand,
                        Categories = o.Product.Categories,
                        QuantityOrder = o.QuantityOrder,
                        TotalMoney = o.TotalMoney
                    }).ToList(),
                TotalMoneyCart = cartResponse.TotalMoneyCart,
            };
        }

        public List<Cart> GetList()
        {
            /*var listCart = _context.Carts
                .Include(c=>c.Orders)
                .Select(c => new CartResponse()
                {
                    CartID = c.CartID,
                    UserID = c.UserID,
                    Orders = _context.Orders
                        .Include(o=>o.Product)
                        .Where(o=>o.OrderID == c.UserID)
                        .Select(o=>new OrderResponse()
                        {
                            OrderID = o.OrderID,
                            UserID = o.UserID,
                            ProductID = o.Product.ProductID,
                            Name = o.Product.Name,
                            Description = o.Product.Description,
                            ImageURL = o.Product.ImageURL,
                            QuantityAvailable = o.Product.QuantityAvailable,
                            Price = o.Product.Price,
                            Size = o.Product.Size,
                            Brand = o.Product.Brand,
                            Categories = o.Product.Categories,
                            TotalMoney = o.TotalMoney
                        }).ToList(),
                    TotalMoneyCart = c.TotalMoneyCart
                }).ToList();#1#
            var listCart = _context.Carts
                .Include(c=>c.Orders)
                .Select(c => new Cart()
                {
                    CartID = c.CartID,
                    UserID = c.UserID,
                    Orders = _context.Orders
                        .Include(o=>o.Product)
                        .Where(o=>o.UserID == c.UserID)
                        .Select(o=>o).ToList(),
                    TotalMoneyCart = c.TotalMoneyCart,
                    IsinBill = c.IsinBill
                }).ToList();
            return listCart;
        }

        public MessageResponse CreateCart(Guid id)
        {
            var checkUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (checkUser == null)
            {
                return  new MessageResponse()
                {
                    Status = 404,
                    Message = "User không tồn tại"
                };
            }
            var ListOrder = _context.Orders
                .Select(o => o).ToList();
            var orders = new List<Order>();
            int totalCart = 0;
            foreach (var order in ListOrder)
            {
                if (order.UserID == id && order.IsinCart == false)
                {
                    orders.Add(order);
                    totalCart = totalCart + order.TotalMoney;
                }
            }

            var newCart = new Cart()
            {
                CartID = Guid.NewGuid(),
                UserID = id,
                Orders = orders,
                TotalMoneyCart = totalCart,
                IsinBill = false
            };
            _context.Add(newCart);
            _context.SaveChanges();
            return new MessageResponse()
            {
                Status = 200,
                Message = "Tạo cart thành công"
            };
        }

        public MessageResponse DeleteCart(Guid id)
        {
            var targetCart = _context.Carts
                .FirstOrDefault(c => c.CartID == id);
            if (targetCart == null)
            {
                return new MessageResponse()
                {
                    Status = 404,
                    Message = "Không tìm thấy cart"
                };
            }

            _context.Remove(targetCart);
            _context.SaveChanges();

            return new MessageResponse()
            {
                Status = 200,
                Message = "Xóa cart thành công"
            };
        }

        public MessageResponse RemoveOrderInCart(RemoveOrderInCartRequest request)
        {
            var targetOrder = _context.Orders
                .FirstOrDefault(o => o.OrderID == request.OrderID);
            _context.Remove(targetOrder);
            var targetCart = _context.Carts.FirstOrDefault(c => c.UserID == request.UserID && c.IsinBill == false);
            int totalCart = 0;
            foreach (var targetCartOrder in targetCart.Orders)
            {
                totalCart = 0 + targetCartOrder.TotalMoney;
            }

            targetCart.TotalMoneyCart = totalCart;
                _context.SaveChanges();
            return new MessageResponse()
            {
                Status = 200,
                Message = "Xoa thanh cong"
            };
        }
    }
}*/