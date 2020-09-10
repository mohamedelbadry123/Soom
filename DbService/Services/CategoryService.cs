using DbServices.Base;
using DbServices.Model;
using Entities.Models;
using Interfaces.Helpers;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DbService.Services
{
    public class CategoryService : BaseService, ICategory
    {

        private readonly SoomDbContext _context;

        public CategoryService(SoomDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Category>> GetAllCategory(UserParams userParam)
        {

            var CategoryInDb = _context.Categories
               .AsQueryable();


            if (!string.IsNullOrEmpty(userParam.Key))
            {
                CategoryInDb = CategoryInDb.Where(c =>
                    c.Name.Contains(userParam.Key) || c.Desc.Contains(userParam.Key));
            }


            return await PagedList<Category>.CreateAsync(CategoryInDb, userParam.PageNumber, userParam.PageSize);

        }

        public async Task<PagedList<Category>> GetAllCategoryWithPagination(DataTablePram dataTablePram)
        {
            var CategoryInDb = _context.Categories
               .AsQueryable();

            if (!string.IsNullOrEmpty(dataTablePram.Key))
            {
                CategoryInDb = CategoryInDb.Where(c =>
                    c.Name.Contains(dataTablePram.Key) || c.Desc.Contains(dataTablePram.Key));
            }
            return await PagedList<Category>.CreateAsync(CategoryInDb, dataTablePram.Skip, dataTablePram.PageSize);

        }

        public async Task<Category> GetCategoryById(int id)
        {
            var Category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);

            return Category;
        }
    }
}
