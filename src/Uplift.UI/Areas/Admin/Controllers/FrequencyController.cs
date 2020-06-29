using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Repository.IRepository;
using Uplift.Models;

namespace Uplift.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FrequencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public FrequencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Frequency frequency = new Frequency();

            if (id == null)
                return View(frequency);

            frequency = _unitOfWork.Frequency.Get(id.GetValueOrDefault());

            if (frequency == null)
                return NotFound();

            return View(frequency);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (frequency.Id == 0)
                    {
                        TempData["Upsert"] = "Added";
                        _unitOfWork.Frequency.Add(frequency);
                    }
                    else
                    {
                        TempData["Upsert"] = "Updated";
                        _unitOfWork.Frequency.Update(frequency);
                    }

                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["Upsert"] = "Error";
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(frequency);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Frequency.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Frequency.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao deletar." });
            }

            _unitOfWork.Frequency.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Frequencia deletada com sucesso." });
        }

        #endregion
    }
}