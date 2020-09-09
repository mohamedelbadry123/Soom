using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Soom.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ICoreBase _coreRepo;
        private readonly ISubCategory _SubCategoryrepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SubCategoryController(ICoreBase coreRepo, ISubCategory SubCategoryrepo, IWebHostEnvironment webHostEnvironment)
        {
            _coreRepo = coreRepo;
            _SubCategoryrepo = SubCategoryrepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            var model = new SubCategory();

            return View("SubCategoryForm", model);
        }

        public async Task<ActionResult> Update(int id)
        {
            var SubCategory = await _SubCategoryrepo.GetSubCategoryById(id);

            return View("SubCategoryForm", SubCategory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(SubCategory model)
        {
            if (!ModelState.IsValid)
            {
                return View("SubCategoryForm", model);
            }

            if (model.Id == 0)
            {
                _coreRepo.Add(model);
            }
            else
            {
                var SubCategory = await _SubCategoryrepo.GetSubCategoryById(model.Id);

                SubCategory.CategoryId = model.CategoryId;
                SubCategory.Desc = model.Desc;
                SubCategory.Name = model.Name;
               
            }

            await _coreRepo.SaveAll();

            return RedirectToAction("Index");
        }

    }
}