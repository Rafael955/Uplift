using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Repository.IRepository;
using Uplift.Models;
using Uplift.UI.Extensions;
using Uplift.Utility;

namespace Uplift.UI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private List<Service> serviceList;

        public CartController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            serviceList = new List<Service>();
        }

        public IActionResult Index()
        {
            return View(GetShoppingCartItems());
        }

        private IEnumerable<Service> GetShoppingCartItems()
        {
            List<int> shoppingCartListIds = _httpContextAccessor.HttpContext.Session.GetObject<List<int>>(SD.SessionCart);

            foreach (var id in shoppingCartListIds)
            {
                var cartItem = _unitOfWork.Service.GetFirstOrDefault(filter: c => c.Id == id);
                serviceList.Add(cartItem);
            }

            return serviceList;
        }
    }
}