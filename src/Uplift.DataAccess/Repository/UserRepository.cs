using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void LockUser(string userId)
        {
            var userFromId = _db.ApplicationUsers.FirstOrDefault(u => u.Id == userId);
            userFromId.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void UnlockUser(string userId)
        {
            var userFromId = _db.ApplicationUsers.FirstOrDefault(u => u.Id == userId);
            userFromId.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
