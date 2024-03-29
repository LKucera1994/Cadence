﻿using API.Extensions;
using AutoMapper;
using Core.Entities.DTOs;
using Core.Entities.OrderAggregate;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderDto orderDto)
        {
            var email = HttpContext.User.GetEmailFromPrinciple();
            var address = _mapper.Map<AppUserDto, Address>(orderDto.ShipToAddress);          
            var order = await _unitOfWork.Order.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            if (order == null)
                return BadRequest("Problem at creating order");

            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(int id)
        {
            var email = HttpContext.User.GetEmailFromPrinciple();

            var order = await _unitOfWork.Order.GetFirstOrDefault(x =>
                    (x.BuyerEmail == email) &&
                    (x.Id == id),
                    includeProperties: "OrderItems,DeliveryMethod");
            
            if (order == null)
                return NotFound("Problem at retrieving order");

            return Ok(_mapper.Map<OrderToReturnDto>(order));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser()
        {
            var email= HttpContext.User.GetEmailFromPrinciple();
            var orders = await _unitOfWork.Order.GetAll(x=> x.BuyerEmail == email,includeProperties: "OrderItems,DeliveryMethod");

            if (orders == null)
                return BadRequest("Problem at retrieving orders");

            return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var email = HttpContext.User.GetEmailFromPrinciple();
            await _unitOfWork.Order.DeleteOrder(id, email);

            return Ok();
        }

        [HttpGet("deliveryMethods")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _unitOfWork.Order.GetDeliveryMethodsAsync();
            if(deliveryMethods == null)
            {
                return BadRequest("Error at retrieving delivery methods");
            }

            return Ok(deliveryMethods);
        }
     
    }
}
