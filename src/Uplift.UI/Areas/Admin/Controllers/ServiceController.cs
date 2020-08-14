using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Repository.IRepository;
using Uplift.Models;
using Uplift.Models.ViewModels;

namespace Uplift.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // IWebHostEnvironment é necessário para que possamos fazer o upload das imagens no servidor.
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public ServiceViewModel ServiceViewModel { get; set; }

        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            if (id != null)
            {
                ServiceViewModel = LoadServiceViewModel();
                ServiceViewModel.Service = _unitOfWork.Service.Get(id.GetValueOrDefault());
                return View(ServiceViewModel);
            }
            else
            {
                return View(LoadServiceViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string webRootPath = _hostEnvironment.WebRootPath;
                    var files = HttpContext.Request.Form.Files;

                    if (ServiceViewModel.Service.Id == 0)
                    {
                        // New Service
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\services");
                        var extension = Path.GetExtension(files[0].FileName);

                        using var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create);

                        files[0].CopyTo(fileStreams);

                        ServiceViewModel.Service.ImageUrl = @"\images\services\" + fileName + extension;

                        TempData["Upsert"] = "Added";
                        _unitOfWork.Service.Add(ServiceViewModel.Service);
                    }
                    else
                    {
                        // Edit Service
                        var serviceFromDb = _unitOfWork.Service.Get(ServiceViewModel.Service.Id);

                        if (files.Count > 0)
                        {
                            string fileName = Guid.NewGuid().ToString();
                            var uploads = Path.Combine(webRootPath, @"images\services");
                            var extension = Path.GetExtension(files[0].FileName);

                            var imagePath = Path.Combine(webRootPath, serviceFromDb.ImageUrl.TrimStart('\\'));

                            if (System.IO.File.Exists(imagePath)) // Se caminho da imagem existe
                            {
                                System.IO.File.Delete(imagePath); // Apaga caminho
                            }

                            using var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create);

                            files[0].CopyTo(fileStreams);

                            ServiceViewModel.Service.ImageUrl = @"\images\services\" + fileName + extension;

                        }
                        else
                        {
                            ServiceViewModel.Service.ImageUrl = serviceFromDb.ImageUrl;
                        }

                        TempData["Upsert"] = "Updated";
                        _unitOfWork.Service.Update(ServiceViewModel.Service);
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
            else
            {
                ServiceViewModel = LoadServiceViewModel();
                return View(ServiceViewModel);
            }
        }

        #region API Calls

        public IActionResult GetAll()
        {
            var json = Json(new { data = _unitOfWork.Service.GetAll(includeProperties: "Category,Frequency") });

            return json;
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Service.Get(id);
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao remover serviço." });
            }

            _unitOfWork.Service.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Serviço removido com sucesso." });
        }

        #endregion

        private ServiceViewModel LoadServiceViewModel()
        {
            return new ServiceViewModel()
            {
                Service = new Service(),
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                FrequencyList = _unitOfWork.Frequency.GetFrequencyListForDropDown()
            };
        }
    }
}
// _unitOfWork.Service.GetAll(includeProperties: "Category,Frequency") 
// includeProperties permite no caso o método GetAll executar Eager Loading das entidades passadas(Category e Frequency) como parametros baseado nos relacionamentos de chave primária e estrangeira definidas entre essas entidades.