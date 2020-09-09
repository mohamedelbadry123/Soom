using Entities.Models;
using Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
   public interface ISubCategory
    {
        Task<List<SubCategory>> GetAllSubCategoryWithPagination(DataTablePram dataTablePram);
        Task<SubCategory> GetSubCategoryById(int id);

    }
}
