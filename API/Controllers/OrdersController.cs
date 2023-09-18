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
    public class OrdersController :ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
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



        

        
    }
}
