using Core.Entities;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }



        public async Task<UserBasket> GetBasketAsync(string basketId)

        {
            var data = await _database.StringGetAsync(basketId);

            if (data.IsNullOrEmpty)
                return null;

            return JsonSerializer.Deserialize<UserBasket>(data);


        }

        public async Task<UserBasket> UpdateBasketAsync(UserBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!created)
                return null;

            return await GetBasketAsync(basket.Id);

        }
    }
}
