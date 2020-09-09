using Entities.Models;
using Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
   public interface IAdvertisements
    {
        Task<List<Advertisment>> GetAllAdvertismentWithPagination(DataTablePram dataTablePram);

        Task<Advertisment> GetAdvertismentById(int id);

    }
}
