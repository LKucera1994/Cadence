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
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _dataContext;
        internal DbSet<Order> _dbSet; 

        public OrderRepository(IBasketRepository basketRepository,IUnitOfWork unitOfWork, DataContext dataContext) : base(dataContext)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _dataContext = dataContext;
            
            _dbSet = dataContext.Set<Order>();
        }

        


        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {

            var basket = await _basketRepository.GetBasketAsync(basketId);

            //Get items from basket

            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                
                var productItem = await _unitOfWork.Product.GetFirstOrDefault(x => x.Id == item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PhotoUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }


            // check if order already exists. if not -> Create Order 

            var deliveryMethod = await _unitOfWork.DeliveryMethod.GetFirstOrDefault(x => x.Id == deliveryMethodId);
            var subtotal = items.Sum(x => x.Price * x.Quantity);

            var order = await _dataContext.Order.FirstOrDefaultAsync(x => x.PaymentIntentId == basket.PaymentIntentId);

            if(order != null)
            {
                // update information that could change between payment intent confirmation and payment confirmation

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

            //save to db

            await _dataContext.SaveChangesAsync();
            await _unitOfWork.Save();

            return order;



        }

        public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.DeliveryMethod.GetAll(x => true);
        }

       

        public async Task DeleteOrder(int orderId, string buyerEmail)
        {
            var order = await _dataContext.Order.FirstOrDefaultAsync(x => x.Id == orderId && x.BuyerEmail == buyerEmail);

            _dataContext.Order.Remove(order);

            

            await _dataContext.SaveChangesAsync();
            



        }
    }
}
