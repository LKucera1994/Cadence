using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface IDeliveryMethodRepository : IGenericRepository<DeliveryMethod>
    {       
    }
}
