using API.Extensions;
using AutoMapper;
using Core.Entities.DTOs;
using Core.Entities.OrderAggregate;
using Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderService, IMapper mapper)
        {

            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.GetEmailFromPrinciple();

            var address = _mapper.Map<AppUserDto, Address>(orderDto.ShipToAddress);
            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            if (order == null)
                return BadRequest("Problem at creating order");

            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int OrderId)
        {
            var email = HttpContext.User.GetEmailFromPrinciple();
            var order = await _orderService.GetFirstOrDefault(x => (x.Id == OrderId));

            if (order == null)
                return NotFound("Problem at retrieving order");


            return Ok(order);

        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrdersForUser()
        {
            var email= HttpContext.User.GetEmailFromPrinciple();
            var orders = await _orderService.GetAll(x => x.BuyerEmail == email);

            if (orders == null)
                return BadRequest("Problem at retrieving orders");


            return Ok(orders);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int OrderId)
        {
            var order = await _orderService.GetFirstOrDefault(x => x.Id == OrderId);
            _orderService.Remove(order);
            var orderAfterDelete = await _orderService.GetFirstOrDefault(x => x.Id == OrderId);

            if (orderAfterDelete == null)
                return Ok();

            else
                return BadRequest("Error at deleting Order");

        }

        [HttpGet("deliveryMethods")]
        [AllowAnonymous]

        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();

            if(deliveryMethods == null)
            {
                return BadRequest("Error at retrieving delivery methods");
            }

            return Ok(deliveryMethods);
        }



        

        
    }
}
