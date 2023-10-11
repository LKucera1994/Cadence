using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public class DeliveryMethod
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string ShortName { get; set; }
        [MaxLength(300)]
        public string DeliveryTime { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
