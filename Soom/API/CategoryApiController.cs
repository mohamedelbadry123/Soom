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
    public class CategoryApiController : ControllerBase
    {

        private readonly ICoreBase _repoCore;
        private readonly ICategory _Category;

        public CategoryApiController(ICoreBase repoCore, ICategory Category)
        {
            _repoCore = repoCore;
            _Category = Category;
        }


        [HttpPost]
        public async Task<IActionResult> GetCategories()
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

                var All = await _Category.GetAllCategory(new UserParams { Key = searchValue ,
                    PageNumber = int.Parse(draw) ,
                    PageSize = pageSize  });
                //Get All By Server Pagination 

                //Get All By Server Pagination  End


                // Send to View 

                var jsonData = new { draw = All.CurrentPage, recordsFiltered = All.TotalCount, recordsTotal = All.TotalCount, data = All };
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