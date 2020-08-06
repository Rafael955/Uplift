using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;

namespace Uplift.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader order);
        void ChangeOrderStatus(int orderHeaderId, string status);
    }
}
