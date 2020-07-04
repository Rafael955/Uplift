using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplift.UI.Extensions;
using Uplift.Utility;

namespace Uplift.UI.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CartController(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public IActionResult Index()
        {
            ViewBag.Lista = GetShoppingCartItems();
            return View();
        }

        private List<int> GetShoppingCartItems()
        {
            return httpContextAccessor.HttpContext.Session.GetObject<List<int>>(SD.SessionCart);
        }
    }
}