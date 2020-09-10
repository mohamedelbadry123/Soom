using Entities.Models;
using Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DbService.Services;

namespace Interfaces.Interfaces
{
   public interface ISubCategory
    {
        Task<PagedList<SubCategoryDatatableViewModel>> GetAllSubCategoryWithPagination(DataTablePram dataTablePram);
        Task<SubCategory> GetSubCategoryById(int id);

    }
}
