using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Repository.IRepository;
using Uplift.Models;
using Uplift.Utility;

namespace Uplift.UI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            
            if (id == null)
                return View(category);
            
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (category.Id == 0)
                    {
                        TempData["Upsert"] = "Added";
                        _unitOfWork.Category.Add(category);
                    }
                    else
                    {
                        TempData["Upsert"] = "Updated";
                        _unitOfWork.Category.Update(category);
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

            return View(category);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            //return Json(new { data = _unitOfWork.Category.GetAll() });
            return Json(new { data = _unitOfWork.SP_Call.ReturnList<Category>(SD.usp_GetAllCategory, null) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);

            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao deletar." });
            }

            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Categoria deletada com sucesso." });
        }

        #endregion
    }
}