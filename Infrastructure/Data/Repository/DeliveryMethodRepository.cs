using Core.Entities.OrderAggregate;
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class DeliveryMethodRepository: GenericRepository<DeliveryMethod> , IDeliveryMethodRepository
    {
        private readonly DataContext dataContext;
        public DeliveryMethodRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        
    }
}
