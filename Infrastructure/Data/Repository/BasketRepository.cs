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
        //private readonly IDatabase _database;
        private readonly DataContext _datacontext;
        internal DbSet<UserBasket> dbSet;

        public BasketRepository(/*IConnectionMultiplexer redis,*/ DataContext datacontext)
        {
            //_database = redis.GetDatabase();
            _datacontext = datacontext;
            this.dbSet = datacontext.Set<UserBasket>();

        }

        public async Task DeleteBasketAsync(string basketId)
        {
            var basket = await _datacontext.UserBaskets.FirstOrDefaultAsync(x=> x.UniqueId == basketId);
            dbSet.Remove(basket);
     
            //return await _database.KeyDeleteAsync(basketId);
        }



        public async Task<UserBasket> GetBasketAsync(string basketId)

        {
            var basket = await _datacontext.UserBaskets.FirstOrDefaultAsync(x => x.UniqueId == basketId);



            return basket;



            //var data = await _database.StringGetAsync(basketId);

            //if (data.IsNullOrEmpty)
            //    return null;

            //return JsonSerializer.Deserialize<UserBasket>(data);


        }

        public async Task<UserBasket> UpdateBasketAsync(UserBasket basket)
        {
            var basketInDb = await _datacontext.UserBaskets.FirstOrDefaultAsync(x => x.UniqueId == basket.UniqueId);

            if (basketInDb == null)
            {
                var created = await _datacontext.AddAsync(basket);

                if (created == null)
                    return null;
              
            }

            else
            {
                basketInDb.LogDate = DateTime.Now;
                dbSet.Update(basket);                
            }
            await _datacontext.SaveChangesAsync();

            return await GetBasketAsync(basket.UniqueId);

            //var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            //if (!created)
            //    return null;

            //return await GetBasketAsync(basket.Id);

        }
    }
}
