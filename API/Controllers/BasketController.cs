﻿using AutoMapper;
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
        

        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new UserBasket(id));
        }
        [HttpPost]
        public async Task<ActionResult<UserBasket>> UpdateBasket(UserBasketDto basket)
        {
            var userBasket = _mapper.Map<UserBasketDto, UserBasket>(basket);
            var updatedBasket = await _basketRepository.UpdateBasketAsync(userBasket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        
        }

        
    }
}
