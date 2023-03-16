using System;
using System.Collections.Generic;
using System.Linq;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace beSS.Services.Impl
{
    public class BillService:IBillService
    {
        private readonly MasterDbContext _context;

        public BillService(MasterDbContext context)
        {
            _context = context;
        }
        public List<BillResponse> GetAll()
        {
            var listBill = _context.Bills
                .Include(b => b.Orders)
                .Select(b => new BillResponse()
                {
                    BillID = b.BillID,
                    UserID = b.UserID,
                    Orders = _context.Orders.Include(o=>o.Product)
                        .Where(o=>o.IDOB == b.BillID && o.UserID == b.UserID && o.IsinBill == true)
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
                            DisplayPrice = o.Product.Price.ToString("#,## VND"),
                            Size = o.Product.Size,
                            Brand = o.Product.Brand,
                            Categories = o.Product.Categories,
                            QuantityOrder = o.QuantityOrder,
                            TotalMoney = o.TotalMoney,
                            DisplayTotalMoney = o.TotalMoney.ToString("#,## VND"),
                            IsinBill = o.IsinBill,
                            BillID = o.IDOB
                        }).ToList(),
                    TotalBill = b.TotalBill,
                    DisplayTotalBill = b.TotalBill.ToString("#,## VND"),
                    AddressTranfer = b.AddressTranfer,
                    AddressDetail = b.AddressDetail,
                    NameCustomer = b.NameCustomer,
                    PhoneNumber = b.PhoneNumber,
                    IsPayed = b.IsPayed
                }).ToList();
            return listBill;
        }

        public BillResponse GetBillById(Guid id)
        {
            var targetBill = _context.Bills.Include(b => b.Orders)
                .FirstOrDefault(b=>b.BillID == id && b.IsPayed == false);
            if (targetBill == null)
            {
                throw new Exception("Not found this bill");
            }

            return new BillResponse()
            {
                BillID = targetBill.BillID,
                UserID = targetBill.UserID,
                Orders = _context.Orders.Include(o=>o.Product)
                    .Where(o=>o.IDOB == targetBill.BillID && o.UserID == targetBill.UserID && o.IsinBill == true)
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
                        DisplayPrice = o.Product.Price.ToString("#,## VND"),
                        Size = o.Product.Size,
                        Brand = o.Product.Brand,
                        Categories = o.Product.Categories,
                        QuantityOrder = o.QuantityOrder,
                        TotalMoney = o.TotalMoney,
                        DisplayTotalMoney = o.TotalMoney.ToString("#,## VND"),
                        IsinBill = o.IsinBill
                    }).ToList(),
                TotalBill = targetBill.TotalBill,
                DisplayTotalBill = targetBill.TotalBill.ToString("#,## VND"),
                AddressTranfer = targetBill.AddressTranfer,
                AddressDetail = targetBill.AddressDetail,
                NameCustomer = targetBill.NameCustomer,
                PhoneNumber = targetBill.PhoneNumber,
                IsPayed = targetBill.IsPayed
            };
        }

        public List<BillResponse> SearchBillByName(string CustomerName)
        {
            var listBill = _context.Bills
                .Where(b=>b.NameCustomer.ToLower().Contains(CustomerName.ToLower()))
                .Select(b => new BillResponse()
                {
                    BillID = b.BillID,
                    UserID = b.UserID,
                    Orders = _context.Orders.Include(o=>o.Product)
                        .Where(o=>o.IDOB == b.BillID && o.UserID == b.UserID && o.IsinBill == true)
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
                            DisplayPrice = o.Product.Price.ToString("#,## VND"),
                            Size = o.Product.Size,
                            Brand = o.Product.Brand,
                            Categories = o.Product.Categories,
                            QuantityOrder = o.QuantityOrder,
                            TotalMoney = o.TotalMoney,
                            DisplayTotalMoney = o.TotalMoney.ToString("#,## VND"),
                            IsinBill = o.IsinBill
                        }).ToList(),
                    TotalBill = b.TotalBill,
                    DisplayTotalBill = b.TotalBill.ToString("#,## VND"),
                    AddressTranfer = b.AddressTranfer,
                    AddressDetail = b.AddressDetail,
                    NameCustomer = b.NameCustomer,
                    PhoneNumber = b.PhoneNumber,
                    IsPayed = b.IsPayed
                }).ToList();
            return listBill;
        }

        public List<BillResponse> GetAllBillNoPayedByUser(Guid id)
        {
            var listBill = _context.Bills
                .Where(b=>b.UserID == id && b.IsPayed == false)
                .Select(b => new BillResponse()
                {
                    BillID = b.BillID,
                    UserID = b.UserID,
                    Orders = _context.Orders.Include(o=>o.Product)
                        .Where(o=>o.IDOB == b.BillID && o.UserID == b.UserID && o.IsinBill == true)
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
                            DisplayPrice = o.Product.Price.ToString("#,## VND"),
                            Size = o.Product.Size,
                            Brand = o.Product.Brand,
                            Categories = o.Product.Categories,
                            QuantityOrder = o.QuantityOrder,
                            TotalMoney = o.TotalMoney,
                            DisplayTotalMoney = o.TotalMoney.ToString("#,## VND"),
                            IsinBill = o.IsinBill
                        }).ToList(),
                    TotalBill = b.TotalBill,
                    DisplayTotalBill = b.TotalBill.ToString("#,## VND"),
                    AddressTranfer = b.AddressTranfer,
                    AddressDetail = b.AddressDetail,
                    NameCustomer = b.NameCustomer,
                    PhoneNumber = b.PhoneNumber,
                    IsPayed = b.IsPayed
                }).ToList();
            return listBill;
        }

        public List<BillResponse> GetAllBillPayedByUser(Guid id)
        {
            var listBill = _context.Bills
                .Where(b=>b.UserID == id && b.IsPayed == true)
                .Select(b => new BillResponse()
                {
                    BillID = b.BillID,
                    UserID = b.UserID,
                    Orders = _context.Orders.Include(o=>o.Product)
                        .Where(o=>o.IDOB == b.BillID && o.UserID == b.UserID && o.IsinBill == true)
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
                            DisplayPrice = o.Product.Price.ToString("#,## VND"),
                            Size = o.Product.Size,
                            Brand = o.Product.Brand,
                            Categories = o.Product.Categories,
                            QuantityOrder = o.QuantityOrder,
                            TotalMoney = o.TotalMoney,
                            DisplayTotalMoney = o.TotalMoney.ToString("#,## VND"),
                            IsinBill = o.IsinBill
                        }).ToList(),
                    TotalBill = b.TotalBill,
                    DisplayTotalBill = b.TotalBill.ToString("#,## VND"),
                    AddressTranfer = b.AddressTranfer,
                    AddressDetail = b.AddressDetail,
                    NameCustomer = b.NameCustomer,
                    PhoneNumber = b.PhoneNumber,
                    IsPayed = b.IsPayed
                }).ToList();
            return listBill;
        }

        public MessageResponse CreateBill(CreateBillRequest request)
        {
            var listOrderTarget = _context.Orders
                .Include(x=>x.Product)
                .Where(o => o.UserID == request.UserID && o.IsinBill == false)
                .Select(o => o).ToList();
            int totalBill = 0;
            foreach (var order in listOrderTarget)
            {
                totalBill = totalBill + order.TotalMoney;
            }

            var listOrder = new List<Guid>();
            foreach (var order in listOrderTarget)
            {
                var OrderID = order.OrderID;
                listOrder.Add(OrderID);
            }

            var newBill = new Bill()
            {
                BillID = Guid.NewGuid(),
                UserID = request.UserID,
                Orders = listOrderTarget,
                TotalBill = totalBill,
                AddressTranfer = request.AddressTranfer,
                AddressDetail = request.AddressDetail,
                NameCustomer = request.NameCustomer,
                PhoneNumber = request.PhoneNumber,
                IsPayed = false,
                OrderIDs = listOrder,
            };
            
            _context.Add(newBill);
            foreach (var order in listOrderTarget)
            {
                order.IsinBill = true;
                order.IDOB = newBill.BillID;
            }
            _context.SaveChanges();
            return new MessageResponse()
            {
                Status = 200,
                Message = "Success"
            };
        }

        public MessageResponse DeleteBill(Guid id)
        {
            var targetBill = _context.Bills.FirstOrDefault(b => b.BillID == id);
            _context.Remove(targetBill);
            _context.SaveChanges();
            return new MessageResponse()
            {
                Status = 200,
                Message = "Xóa thành công"
            };
        }

        public MessageResponse ConFirmBill(Guid id)
        {
            var targetBill = _context.Bills.FirstOrDefault(x => x.BillID == id && x.IsPayed == false);
            if (targetBill == null)
            {
                return new MessageResponse()
                {
                    Status = 400,
                    Message = "Không tìm thấy hóa đơn này"
                };
            }

            targetBill.IsPayed = true;
            
            foreach (var orderID in targetBill.OrderIDs)
            {
                var targetOrder = _context.Orders
                    .Include(x=>x.Product)
                    .FirstOrDefault(x => x.OrderID == orderID);
                if (targetOrder == null)
                {
                    return new MessageResponse()
                    {
                        Status = 400,
                        Message = "Không tìm thấy order này"
                    };
                }

                var targetProduct = _context.Products.FirstOrDefault(x => x.ProductID == targetOrder.Product.ProductID);
                if (targetProduct == null)
                {
                    return new MessageResponse()
                    {
                        Status = 400,
                        Message = "Không tìm thấy sản phẩm này"
                    };
                }

                targetProduct.QuantityAvailable = targetProduct.QuantityAvailable - targetOrder.QuantityOrder;
            }

            _context.SaveChanges();
            return new MessageResponse()
            {
                Status = 200,
                Message = "Success"
            };

        }
    }
}