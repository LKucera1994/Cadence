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
    public class OrderRepository : Repository<Order>/*, /*IOrderRepository*/ 
    {
        
        private readonly IBasketRepository _basketRepository;
        private readonly DataContext  _dataContext;

        private readonly IUnitOfWork _unitOfWork;

        public OrderRepository(IBasketRepository basketRepository, DataContext dataContext) : base(dataContext)
        {
            
           
            _basketRepository = basketRepository;

            _dataContext = dataContext;
            
            
        }

        //public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        //{

        //    var basket = await _basketRepository.GetBasketAsync(basketId);

        //    //Get items from basket

        //    var items = new List<OrderItem>();
        //    foreach(var item in basket.Items)
        //    {
        //        var productItem= await _unitOfWork.Product.GetFirstOrDefault(x => x.Id == item.Id);
        //        var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PhotoUrl);
        //        var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
        //        items.Add(orderItem);
        //    }


        //    //Create Order 

        //    var deliveryMethod = await _unitOfWork.DeliveryMethod.GetFirstOrDefault(x => x.Id == deliveryMethodId);        
        //    var subtotal = items.Sum(x => x.Price * x.Quantity);
        //    var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subtotal);

        //    //save to db

            
        //    _dataContext.Add(order);
        //    var result = await _unitOfWork.Save();

            

        //    if(result <= 0)
        //    {
        //        return null;
        //    }

        //    //delete Basket
        //    await _basketRepository.DeleteBasketAsync(basketId);

        //    return order;


        //}

        //public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()
        //{
        //    return await  _unitOfWork.DeliveryMethod.GetAll(x => true);
        //}

        //public Task<Order> UpdateOrderAsync(Order order)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
