using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {      
        private readonly IUnitOfWork _unitOfWork;      
        private readonly IConfiguration _config; 
        

        public PaymentService( IUnitOfWork unitOfWork, IConfiguration config)
        { 
            _unitOfWork = unitOfWork;            
            _config = config;           
        }

        public async Task<UserBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var basket = await _unitOfWork.Basket.GetBasketAsync(basketId);
            
            if (basket == null)
                return null;

            var shippingPrice = 0m;

            if(basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.DeliveryMethod.GetFirstOrDefault(x => x.Id == basket.DeliveryMethodId);
                shippingPrice = deliveryMethod.Price;
            }

            foreach(var item in basket.Items)
            {
                var productItem = await _unitOfWork.Product.GetFirstOrDefault(x=> x.Id == item.Id);
                if(item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }

            }

            var service = new PaymentIntentService();
            PaymentIntent intent; 

            if(string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {                    
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
                    Currency = "eur",
                    PaymentMethodTypes = new List<string> { "card" }

                };

                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }

            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
                };

                await service.UpdateAsync(basket.PaymentIntentId, options);
                
            }

            await _unitOfWork.Basket.UpdateBasketAsync(basket);
            await _unitOfWork.Save();           

            return basket;

        }

        public async Task<Order> UpdateOrderPaymentFailed(string paymentIntentId)
        {
            var order = await _unitOfWork.Order.GetFirstOrDefault(x=> x.PaymentIntentId == paymentIntentId);

            if (order == null)
                return null;

            order.Status = OrderStatus.PaymentFailed;
            await _unitOfWork.Save();
            return order;
            
        }

        public async Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
            var order = await _unitOfWork.Order.GetFirstOrDefault(x => x.PaymentIntentId == paymentIntentId);

            if (order == null)
                return null;

            order.Status = OrderStatus.PaymentReceived;
            await _unitOfWork.Save();
            return order;
        }
    }
}
