using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{

    public class UserBasket
    {   
        public int Id { get; set; }

        [ValidateNever]
        public string UniqueId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
        public DateTime LogDate { get; set; } = DateTime.UtcNow;

        public UserBasket()
        {
        }
        public UserBasket(string id)
        {
            UniqueId = id;
        }

    }
}
