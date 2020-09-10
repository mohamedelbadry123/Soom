using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Interfaces.Interfaces;
using Interfaces.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Soom.Models;

namespace Soom.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICoreBase _coreRepo;
        private readonly ICategory _Categoryrepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ICoreBase coreRepo, ICategory Categoryrepo, IWebHostEnvironment webHostEnvironment)
        {
            _coreRepo = coreRepo;
            _Categoryrepo = Categoryrepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            var model = new CategoryViewModel
            {
                Category = new Category(),
                Image = null

            };

            return View("CategoryForm", model);
        }

        public async Task<ActionResult> Update(int id)
        {
            var Category = await _Categoryrepo.GetCategoryById(id);


            var model = new CategoryViewModel
            {
                Category = Category,
                Image = null

            };
            return View("CategoryForm", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(CategoryViewModel collection)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", collection);
            }
            var root = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");


            if (collection.Category.Id == 0)
            {
                if (collection.Image == null)
                {
                    collection.Error = "Please Add Image !";

                    return View("CategoryForm", collection);
                }

                string fileName;
                var isImageSaved = _coreRepo.SaveSingleImageFormFile(root, collection.Image, out fileName);
                if (!isImageSaved)
                {
                    collection.Error = "There was an error in raising the pictures !";
                }

                collection.Category.Image = fileName;
                _coreRepo.Add(collection.Category);
                await _coreRepo.SaveAll();


            }
            else
            {
                var Category = await _Categoryrepo.GetCategoryById(collection.Category.Id);

                Category.Name = collection.Category.Name;
                Category.Desc = collection.Category.Desc;


                

                if (collection.Image != null)
                {
                    var CategoryImage = await _Categoryrepo.GetCategoryById(Category.Id);


                    string fullPath = root + "/" + CategoryImage.Image;
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }



                    string fileName;
                    var isImageSaved = _coreRepo.SaveSingleImageFormFile(root, collection.Image, out fileName);
                    if (!isImageSaved)
                    {
                        collection.Error = "There was an error in raising the pictures !";
                    }
                    Category.Image = fileName;


                }
            }

            await _coreRepo.SaveAll();


            return RedirectToAction("Index");
        }
    }
}