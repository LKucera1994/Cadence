using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PaymentsController : ControllerBase
    {
        
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentsController> _logger;
        private readonly IConfiguration _config;
        private string WhSecret; 
        public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger, IConfiguration config)
        {
            _paymentService = paymentService;
            _logger = logger;
            _config = config;
            WhSecret = _config["StripeSettings:WhSecret"];
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<UserBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket =  await _paymentService.CreateOrUpdatePaymentIntent(basketId);

            if (basket == null)
                return BadRequest("Problem with Basket");

            return Ok(basket);
        }

        [AllowAnonymous]
        [HttpPost("webhook")]

        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret, throwOnApiVersionMismatch: false);

            PaymentIntent paymentIntent;
            Order order;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    paymentIntent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment succeeded: ", paymentIntent.Id);

                    order = await _paymentService.UpdateOrderPaymentSucceeded(paymentIntent.Id);
                    _logger.LogInformation("Order updated to payment received: " ,order.Id);
                    break;

                case "payment_intent.payment_failed":
                    paymentIntent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment failed: ", paymentIntent.Id);

                    order = await _paymentService.UpdateOrderPaymentFailed(paymentIntent.Id);
                    _logger.LogInformation("Order updated to payment failed: ", order.Id);
                    break;        
            }

            return new EmptyResult();
        }
        
    }
}
