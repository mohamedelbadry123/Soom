using Entities.Models;
using Interfaces.Base;
using Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
   public interface ICategory : IService
    {
        Task<List<Category>> GetAllCategory();
        Task<PagedList<Category>> GetAllCategoryWithPagination(DataTablePram dataTablePram);

        Task<Category> GetCategoryById(int id);
    }
}
