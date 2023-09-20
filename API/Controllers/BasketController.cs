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
            var basket = await _unitOfWork.Basket.GetFirstOrDefault(x => x.Id == id);

            await _unitOfWork.Save();

            if (basket == null)
                return NotFound("Problem at finding Basket");

            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBasket(UserBasketDto basket)
        {
            var userBasket = _mapper.Map<UserBasketDto, UserBasket>(basket);

            var result = await _unitOfWork.Basket.Add(userBasket);

            await _unitOfWork.Save();

            if (result == null)
                BadRequest("Problem at creating Basket");



            return Ok("Basket created succesfully");
        }



        [HttpPut]
        public async Task<ActionResult<UserBasket>> UpdateBasket(UserBasketDto basket)
        {

            var userBasket = _mapper.Map<UserBasketDto, UserBasket>(basket);

            await _unitOfWork.Basket.UpdateBasketAsync(userBasket);
            await _unitOfWork.Save();

            
            return Ok();
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            var basket = await _unitOfWork.Basket.GetFirstOrDefault(x => x.Id == id);
            _unitOfWork.Basket.Remove(basket);
            await _unitOfWork.Save();

        }


    }
}
