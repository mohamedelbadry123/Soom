using DbServices.Base;
using DbServices.Model;
using Entities.Models;
using Interfaces.Helpers;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbService.Services
{
    public class SubCategoryService : BaseService, ISubCategory
    {
        private readonly SoomDbContext _context;

        public SubCategoryService(SoomDbContext context)
        {
            _context = context;
        }

        public Task<List<SubCategory>> GetAllSubCategoryWithPagination(DataTablePram dataTablePram)
        {
            throw new NotImplementedException();
        }

        public async Task<SubCategory> GetSubCategoryById(int id)
        {
            var SubCategory = await _context.SubCategorys.SingleOrDefaultAsync(c => c.Id == id);

            return SubCategory;
        }
    }
}
