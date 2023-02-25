using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Core.Repositories.Base;
using Ordering.Infrastrcture.Data;
using Ordering.Infrastrcture.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastrcture.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
        }

        public Task<IEnumerable<Order>> GetOrderByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}