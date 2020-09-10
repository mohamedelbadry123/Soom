using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Interfaces.Interfaces;
using Interfaces.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Soom.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ICoreBase _coreRepo;
        private readonly ISubCategory _SubCategoryrepo;
        private readonly ICategory _Categoryrepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SubCategoryController(ICategory Categoryrepo,ICoreBase coreRepo, ISubCategory SubCategoryrepo, IWebHostEnvironment webHostEnvironment)
        {
            _coreRepo = coreRepo;
            _SubCategoryrepo = SubCategoryrepo;
            _webHostEnvironment = webHostEnvironment;
            _Categoryrepo = Categoryrepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {

            var model = new SubCategoryViewModel()
            {
                Categories = await _Categoryrepo.GetAllCategory(),
                 SubCategory = new SubCategory()
            };

            return View("SubCategoryForm", model);
        }

        public async Task<ActionResult> Update(int id)
        {
            var SubCategory = await _SubCategoryrepo.GetSubCategoryById(id);


            var model = new SubCategoryViewModel()
            {
                Categories = await _Categoryrepo.GetAllCategory(),
                SubCategory = SubCategory
            };
            return View("SubCategoryForm", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(SubCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SubCategoryForm", model);
            }

            if (model.SubCategory.Id == 0)
            {
                _coreRepo.Add(model.SubCategory);
            }
            else
            {
                var SubCategory = await _SubCategoryrepo.GetSubCategoryById(model.SubCategory.Id);

                SubCategory.CategoryId = model.SubCategory.CategoryId;
                SubCategory.Desc = model.SubCategory.Desc;
                SubCategory.Name = model.SubCategory.Name;
               
            }

            await _coreRepo.SaveAll();

            return RedirectToAction("Index");
        }

    }
}