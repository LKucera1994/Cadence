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
    public class BasketRepository : Repository<UserBasket> ,IBasketRepository
    {
        private readonly DataContext _dataContext;
        public BasketRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task UpdateBasketAsync(UserBasket basket)
        {
            _dataContext.Entry(basket).State = EntityState.Modified;

            
            

        }
       

        



        //public async Task<UserBasket> GetBasketAsync(string basketId)
        //{
        //    var data = await _dataContext.StringGetAsync(basketId);

        //    if (data.IsNullOrEmpty)
        //        return null;

        //    return JsonSerializer.Deserialize<UserBasket>(data);
            
            
        //}

        //public async Task<UserBasket> UpdateBasketAsync(UserBasket basket)
        //{
        //    var created = await _dataContext.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

        //    if (!created)
        //        return null;

        //    return await GetBasketAsync(basket.Id);

        //}
    }
}
