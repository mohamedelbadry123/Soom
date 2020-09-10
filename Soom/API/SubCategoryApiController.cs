using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Helpers;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Soom.API
{
    [Route("[controller]")]
    [ApiController]
    public class SubCategoryApiController : ControllerBase
    {
        private readonly ICoreBase _repoCore;
        private readonly ISubCategory _SubCategory;

        public SubCategoryApiController(ICoreBase repoCore, ISubCategory SubCategory)
        {
            _repoCore = repoCore;
            _SubCategory = SubCategory;
        }


        [HttpPost]
        public async Task<IActionResult> GetSubCategories()
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
                var AllSubCategory = await _SubCategory.GetAllSubCategoryWithPagination(new DataTablePram
                {
                    Key = searchValue,
                    PageSize = pageSize,
                    Skip = Page
                });
                //Get All By Server Pagination  End


                // Send to View 

               
                var jsonData = new { draw = draw, recordsFiltered = AllSubCategory.TotalCount, recordsTotal = AllSubCategory.TotalCount, data = AllSubCategory };
                // Send to View End
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}