using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Repository.IRepository;
using Uplift.Models;
using Uplift.Models.ViewModels;
using Uplift.UI.Extensions;
using Uplift.Utility;

namespace Uplift.UI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(LoadHomeViewModel());
        }

        public IActionResult Details(int id)
        {
            var serviceFromDb = _unitOfWork.Service.GetFirstOrDefault(includeProperties: "Category,Frequency", filter: c => c.Id == id);

            return View(serviceFromDb);
        }

        public IActionResult AddToCart(int serviceId)
        {
            List<int> sessionList = new List<int>();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SD.SessionCart))) // Se não tem nada na sessão...
            {
                sessionList.Add(serviceId); // adiciona Id do serviço na Lista de Seção.
                HttpContext.Session.SetObject(SD.SessionCart, sessionList); // Adiciona a lista na sessão.
            }
            else
            { // Se não...
                sessionList = HttpContext.Session.GetObject<List<int>>(SD.SessionCart); // Recupera lista da sessão.

                if (!sessionList.Contains(serviceId)) // Se lista de sessões não tiver o Id do serviço passado por parametro, então...
                {
                    sessionList.Add(serviceId); // Adiciona o novo Id na Lista...
                    HttpContext.Session.SetObject(SD.SessionCart, sessionList); // E adiciona a lista novamente na session com o novo Id. 
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private HomeViewModel LoadHomeViewModel()
        {
            return new HomeViewModel
            {
                CategoryList = _unitOfWork.Category.GetAll(),
                ServiceList = _unitOfWork.Service.GetAll(includeProperties: "Frequency"),
            };
        }
    }
}
