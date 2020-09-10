using DbServices.Base;
using DbServices.Model;
using Entities.Models;
using Interfaces.Helpers;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PagedList<SubCategory>> GetAllSubCategoryWithPagination(DataTablePram dataTablePram)
        {
            var SubCategoryInDb = _context.SubCategorys.Include(c=> c.Category)
                         .AsQueryable();

            if (!string.IsNullOrEmpty(dataTablePram.Key))
            {
                SubCategoryInDb = SubCategoryInDb.Where(c =>
                    c.Desc.Contains(dataTablePram.Key)
                    || c.Category.Name.ToString().Contains(dataTablePram.Key)
                    || c.Name.ToString().Contains(dataTablePram.Key)
                    );
            }

            return await PagedList<SubCategory>.CreateAsync(SubCategoryInDb, dataTablePram.Skip, dataTablePram.PageSize);
        }

        public async Task<SubCategory> GetSubCategoryById(int id)
        {
            var SubCategory = await _context.SubCategorys.SingleOrDefaultAsync(c => c.Id == id);

            return SubCategory;
        }
    }
}
