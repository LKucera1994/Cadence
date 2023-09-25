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
    public class OrderService : Repository<Order>, IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _dataContext;
        internal DbSet<Order> _dbSet; 

        public OrderService(IBasketRepository basketRepository,IUnitOfWork unitOfWork, DataContext dataContext) : base(dataContext)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _dataContext = dataContext;
            _dbSet = dataContext.Set<Order>();
        }

        

        public async Task<IEnumerable<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            

            return await _dbSet.Where(x => x.BuyerEmail == buyerEmail)
                .Include("OrderItems")
                .Include("DeliveryMethod")
                .ToListAsync();
        }


        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            return await _dbSet.Include("OrderItems")
                .Include("DeliveryMethod")
                .FirstOrDefaultAsync(x => (x.Id == id) && (x.BuyerEmail == buyerEmail));

        
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


            //Create Order 

            var deliveryMethod = await _unitOfWork.DeliveryMethod.GetFirstOrDefault(x => x.Id == deliveryMethodId);
            var subtotal = items.Sum(x => x.Price * x.Quantity);
            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subtotal);


            //save to db

            _dataContext.Add(order);
            await _dataContext.SaveChangesAsync();
            await _unitOfWork.Save();
            

            //delete Basket
            await _basketRepository.DeleteBasketAsync(basketId);

            return order;


        }

        public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.DeliveryMethod.GetAll(x => true);
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrder(int orderId, string buyerEmail)
        {
            var order = await this.GetOrderByIdAsync(orderId, buyerEmail);

            _dbSet.Remove(order);

            await _dataContext.SaveChangesAsync();
            



        }
    }
}
