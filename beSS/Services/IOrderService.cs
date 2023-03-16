using System;
using System.Collections.Generic;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;

namespace beSS.Services
{
    public interface IOrderService
    {
        List<OrderResponse> GetOrder();
        List<OrderResponse> GetOrderByUser(Guid id);
        OrderResponse CreateOrder(CreateOrder request);
        OrderResponse EditOrder(EditOrder request);
        MessageResponse DeleteOrder(Guid guid);
    }
}