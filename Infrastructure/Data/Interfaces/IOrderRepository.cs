using Core.Entities.OrderAggregate;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface IOrderRepository :IGenericRepository<Order>
    {
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress);       
        Task DeleteOrder(int orderId, string buyerEmail);
        Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
