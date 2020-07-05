using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uplift.DataAccess.Data;
using Uplift.DataAccess.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails order)
        {

            var objFromDb = _db.OrdersHeaders.FirstOrDefault(x => x.Id == order.Id);

            //objFromDb.Name = order.Name;
            //objFromDb.OrderDate = order.OrderDate;
            //objFromDb.Phone = order.Phone;
            //objFromDb.ServiceCount = order.ServiceCount;
            //objFromDb.Status = order.Status;
            //objFromDb.Comments = order.Comments;
            //objFromDb.Email = order.Email;

            //objFromDb.Address = order.Address;
            //objFromDb.ZipCode = order.ZipCode;
            //objFromDb.City = order.City;

            _db.SaveChanges();
        }
    }
}
