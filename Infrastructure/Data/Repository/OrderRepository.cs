using Core.Entities.OrderAggregate;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly IBasketRepository _basketRepository;       
        private readonly DataContext _dataContext;
        internal DbSet<Order> _dbSet; 

        public OrderRepository(IBasketRepository basketRepository,DataContext dataContext) : base(dataContext)
        {
            _basketRepository = basketRepository;
            _dataContext = dataContext;
            
            _dbSet = dataContext.Set<Order>();
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {

            var basket = await _basketRepository.GetBasketAsync(basketId);

            var items = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var productItem = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == item.Id);                 
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PhotoUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
        
            var deliveryMethod = await _dataContext.DeliveryMethods.FirstOrDefaultAsync(x => x.Id == deliveryMethodId);     
            var subtotal = items.Sum(x => x.Price * x.Quantity);                    
            var order = await _dataContext.Order.FirstOrDefaultAsync(x => x.PaymentIntentId == basket.PaymentIntentId);

            if(order != null)
            {               
                order.ShipToAddress = shippingAddress;
                order.DeliveryMethod = deliveryMethod;
                order.Subtotal = subtotal;
                Update(order);             
            }

            else
            {
                order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subtotal, basket.PaymentIntentId);
                _dataContext.Add(order);            
            }
           
            await _dataContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _dataContext.DeliveryMethods.ToListAsync();         
        }

        public async Task DeleteOrder(int orderId, string buyerEmail)
        {
            var order = await _dataContext.Order.FirstOrDefaultAsync(x => x.Id == orderId && x.BuyerEmail == buyerEmail);

            _dataContext.Order.Remove(order);           
            await _dataContext.SaveChangesAsync();        
        }
    }
}
