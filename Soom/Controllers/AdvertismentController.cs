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

namespace Soom.Controllers
{
    public class AdvertismentController : Controller
    {
        private readonly ICoreBase _coreRepo;
        private readonly IAdvertisements _Advertismentrepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdvertismentController(ICoreBase coreRepo, IAdvertisements Advertismentrepo, IWebHostEnvironment webHostEnvironment)
        {
            _coreRepo = coreRepo;
            _Advertismentrepo = Advertismentrepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            var model = new AdvertismentViewModel()
            {
                Advertisment = new Advertisment(),
                File = null
            };

            return View("AdvertismentForm", model);
        }

        public async Task<ActionResult> Update(int id)
        {
            var Advertisment = await _Advertismentrepo.GetAdvertismentById(id);


            var model = new AdvertismentViewModel
            {
                Advertisment = Advertisment,
                File = null

            };
            
            return View("AdvertismentForm", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(AdvertismentViewModel collection)
        {
           

            if (!ModelState.IsValid)
            {
                return View("AdvertismentForm", collection);
            }

            var root = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");


            if (collection.Advertisment.Id == 0)
            {
                if (collection.File == null)
                {
                    collection.Error = "Please Add Image !";

                    return View("CategoryForm", collection);
                }

                string fileName;
                var isImageSaved = _coreRepo.SaveSingleImageFormFile(root, collection.File, out fileName);
                if (!isImageSaved)
                {
                    collection.Error = "There was an error in raising the pictures !";
                }
                collection.Advertisment.File = fileName;
                collection.Advertisment.IsActive = true;
                _coreRepo.Add(collection.Advertisment);
                await _coreRepo.SaveAll();


            }
            else
            {
                var Advertisment = await _Advertismentrepo.GetAdvertismentById(collection.Advertisment.Id);

                Advertisment.CountDays = collection.Advertisment.CountDays;
                Advertisment.Description = collection.Advertisment.Description;
                Advertisment.File = collection.Advertisment.File;
                Advertisment.StartDate = collection.Advertisment.StartDate;
                Advertisment.Subject = collection.Advertisment.Subject;
                Advertisment.Title = collection.Advertisment.Title;
                Advertisment.UriLink = collection.Advertisment.UriLink;



                if (collection.File != null)
                {
                   
                    string fullPath = root + "/" + Advertisment.File;
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }



                    string fileName;
                    var isImageSaved = _coreRepo.SaveSingleImageFormFile(root, collection.File, out fileName);
                    if (!isImageSaved)
                    {
                        collection.Error = "There was an error in raising the pictures !";
                    }
                    Advertisment.File = fileName;


                }
            }

            await _coreRepo.SaveAll();


            return RedirectToAction("Index");
        }

    }
}