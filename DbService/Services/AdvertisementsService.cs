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
    public class AdvertisementsService : BaseService, IAdvertisements
    {

        private readonly SoomDbContext _context;

        public AdvertisementsService(SoomDbContext context)
        {
            _context = context;
        }

        public async Task<Advertisment> GetAdvertismentById(int id)
        {
            var Advertisment = await _context.Advertisments.SingleOrDefaultAsync(c => c.Id == id);

            return Advertisment;
        }

        public async Task<List<Advertisment>> GetAllAdvertismentWithPagination(DataTablePram dataTablePram)
        {
            var AdvertismentInDb = await _context.Advertisments
            .Skip(dataTablePram.Skip).Take(dataTablePram.PageSize)
            .ToListAsync();


            if (!string.IsNullOrEmpty(dataTablePram.Key))
            {
                AdvertismentInDb = AdvertismentInDb.Where(c =>
                 c.Description.Contains(dataTablePram.Key) ||
                 c.Title.Contains(dataTablePram.Key) ||
                 c.UriLink.Contains(dataTablePram.Key) ||
                 c.Subject.Contains(dataTablePram.Key)).ToList();
            }


            return AdvertismentInDb;
        }
    }
}
