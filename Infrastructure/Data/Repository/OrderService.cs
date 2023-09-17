using Core.Entities.OrderAggregate;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class OrderService : Repository<Order>, IOrderService
    {
        private readonly DataContext _dataContext;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDeliveryMethodRepository _deliveryMethodRepository;

        public OrderService(DataContext dataContext, IBasketRepository basketRepository, IProductRepository productRepository, IDeliveryMethodRepository deliveryMethodRepository) : base(dataContext)
        {
            _dataContext = dataContext;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _deliveryMethodRepository = deliveryMethodRepository;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {

            var basket = await _basketRepository.GetBasketAsync(basketId);

            var items = new List<OrderItem>();
            foreach(var item in basket.Items)
            {
                var productItem= await _productRepository.GetFirstOrDefault(x=> x.Id == item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PhotoUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _deliveryMethodRepository.GetFirstOrDefault(x => x.Id == deliveryMethodId);

            
            var subtotal = items.Sum(x => x.Price * x.Quantity);

            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subtotal);

            return order;


        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
