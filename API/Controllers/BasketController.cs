using AutoMapper;
using Core.Entities;
using Core.Entities.DTOs;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BasketController(IUnitOfWork unitOfWork, IMapper mapper)
        {        
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserBasket>> GetBasketById(string id)
        {
            var basket = await _unitOfWork.Basket.GetBasketAsync(id);
            return Ok(basket ?? new UserBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserBasket>> CreateBasket(UserBasketDto basket)
        {
            var userBasket = _mapper.Map<UserBasketDto, UserBasket>(basket);
            var result = await _unitOfWork.Basket.UpdateBasketAsync(userBasket);

            if (result == null)
                BadRequest("Problem at creating Basket");

            return Ok(result);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _unitOfWork.Basket.DeleteBasketAsync(id);

        }
    }
}
