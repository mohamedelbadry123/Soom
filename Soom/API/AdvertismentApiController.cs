using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Interfaces.Helpers;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Soom.API
{
    [Route("[controller]")]
    [ApiController]
    public class AdvertismentApiController : ControllerBase
    {
        private readonly ICoreBase _repoCore;
        private readonly IAdvertisements _Advertisment;

        public AdvertismentApiController(ICoreBase repoCore, IAdvertisements Advertisment)
        {
            _repoCore = repoCore;
            _Advertisment = Advertisment;
        }


        [HttpPost]
        public async Task<IActionResult> AllAdvertisment()
        {
            try
            {
                // Datatable Properties
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
               
                // Datatable Properties End
                int Page = (int.Parse(start) / pageSize);
                //Get All By Server Pagination 
                var AllCategory = await _Advertisment.GetAllAdvertismentWithPagination(new DataTablePram
                {
                    Key = searchValue,
                    PageSize = pageSize,
                    Skip = Page
                });
                //Get All By Server Pagination  End


                // Send to View 

                var data = AllCategory;
                var jsonData = new { recordsFiltered = AllCategory.TotalCount, recordsTotal = AllCategory.TotalCount, data = AllCategory };
                // Send to View End
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


       
        [HttpGet("Delete")]
        public async Task<IActionResult> DeleteAdvertisment(int id)
        {
            var Advertisment = await _Advertisment.GetAdvertismentById(id);

            Advertisment.IsActive = false;

            await _repoCore.SaveAll();
         

           

            

            return Ok();
        }



    }
}