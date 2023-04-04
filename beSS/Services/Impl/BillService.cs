using System;
using System.Collections.Generic;
using System.Globalization;
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
                    DateCreated = b.DateCreated.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
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
                            BillID = o.IDOB,
                            
                        }).ToList(),
                    TotalBill = b.TotalBill,
                    DisplayTotalBill = b.TotalBill.ToString("#,## VND"),
                    AddressTranfer = b.AddressTranfer,
                    AddressDetail = b.AddressDetail,
                    NameCustomer = b.NameCustomer,
                    FullNameUser = b.FullNameUser,
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
                DateCreated = targetBill.DateCreated.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
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
                FullNameUser = targetBill.FullNameUser,
                PhoneNumber = targetBill.PhoneNumber,
                IsPayed = targetBill.IsPayed
            };
        }

        public List<BillResponse> SearchBillByName(string CustomerName)
        {
            var listBill = _context.Bills
                .Where(b=>b.FullNameUser.ToLower().Contains(CustomerName.ToLower()))
                .Select(b => new BillResponse()
                {
                    BillID = b.BillID,
                    UserID = b.UserID,
                    DateCreated = b.DateCreated.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
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
                    FullNameUser = b.FullNameUser,
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
                    DateCreated = b.DateCreated.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),

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
                    FullNameUser = b.FullNameUser,
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
                    DateCreated = b.DateCreated.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
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
                    FullNameUser = b.FullNameUser,
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
                DateCreated = DateTime.UtcNow,
                Orders = listOrderTarget,
                TotalBill = totalBill,
                AddressTranfer = request.AddressTranfer,
                AddressDetail = request.AddressDetail,
                NameCustomer = request.NameCustomer,
                FullNameUser = _context.Users.FirstOrDefault(x=>x.Id == request.UserID).Name,
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

        public RevenueResponse CalculatorRevenue()
        {
            var totalRevenue = _context.Bills.Sum(x => x.TotalBill);
            var countBill = _context.Bills.Count();
            var maxBill = _context.Bills.Max(x => x.TotalBill);
            var minBill = _context.Bills.Min(x => x.TotalBill);
            var revenue = new RevenueResponse()
            {
                TotalRevenue = totalRevenue,
                MaxRevenue = maxBill,
                CountBill = countBill,
                MinRevenue = minBill,
            };
            return revenue;
        }

        public RevenueMonth GetRevenueMonth(int Month ,int Year)
        {
            
            var revenueMonth = new RevenueMonth()
            {
                Month = Month,
                RevenueResponse = new RevenueResponse()
                {
                    TotalRevenue = _context.Bills.Where(x => x.DateCreated.Month == Month && x.DateCreated.Year == Year).Sum(x => x.TotalBill),
                    CountBill =  _context.Bills.Where(x => x.DateCreated.Month == Month && x.DateCreated.Year == Year).Count(),
                    MaxRevenue = _context.Bills.Where(x=>x.DateCreated.Month == Month && x.DateCreated.Year == Year).Max(x=>x.TotalBill),
                    MinRevenue = _context.Bills.Where(x=>x.DateCreated.Month == Month && x.DateCreated.Year == Year).Min(x=>x.TotalBill)
                },
                BillResponses = _context.Bills.Where(x=>x.DateCreated.Month == Month && x.DateCreated.Year == Year)
                    .Select(x=> new BillResponse()
                    {
                        BillID = x.BillID,
                        UserID = x.UserID,
                        DateCreated = x.DateCreated.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                        Orders = _context.Orders.Include(o=>o.Product)
                            .Where(o=>o.IDOB == x.BillID && o.UserID == x.UserID && o.IsinBill == true)
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
                        TotalBill = x.TotalBill,
                        DisplayTotalBill = x.TotalBill.ToString("#,## VND"),
                        AddressTranfer = x.AddressTranfer,
                        AddressDetail = x.AddressDetail,
                        NameCustomer = x.NameCustomer,
                        FullNameUser = x.FullNameUser,
                        PhoneNumber = x.PhoneNumber,
                        IsPayed = x.IsPayed
                        
                    }).ToList()
            };
            return revenueMonth;
        }

        public RatioResponse GetRatioRevenue(int Year)
        {
            var revenueYear = _context.Bills.Where(x => x.DateCreated.Year == Year).Sum(x => x.TotalBill);
            decimal ratioJan = Math.Round((decimal)_context.Bills
                .Where(x => x.DateCreated.Month == 1 && x.DateCreated.Year == Year)
                .Sum(x => x.TotalBill) / revenueYear * 100,2);
            
            if (ratioJan == null)
            {
                ratioJan = 0;
            }
            var ratioRevenue = new RatioResponse()
            {
                Jan = 1,
                RatioJan = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 1 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Feb = 2,
                RatioFeb =  Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 2 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Mar = 3,
                RatioMar =  Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 3 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Apr = 4,
                RatioApr =  Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 4 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                May = 5,
                RatioMay =  Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 5 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Jun = 6,
                RatioJun = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 6 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Jul = 7,
                RatioJul = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 7 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Aug = 8,
                RatioAug = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 8 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Sep = 9,
                RatioSep = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 9 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Oct = 10,
                RatioOct = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 10 && x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Nov = 11,
                RatioNov = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 11&& x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
                Dec = 12,
                RatioDec = Math.Round((decimal)_context.Bills
                    .Where(x => x.DateCreated.Month == 12&& x.DateCreated.Year == Year)
                    .Sum(x => x.TotalBill) / revenueYear * 100,2),
            };
            return ratioRevenue;
        }

        public List<int> ListYear()
        {
            var years = _context.Bills.Where(x=>x.IsPayed == true).Select(x => x.DateCreated.Year).ToList();
            var listYear = years.Distinct().ToList();
            return listYear;
        }
    }
}