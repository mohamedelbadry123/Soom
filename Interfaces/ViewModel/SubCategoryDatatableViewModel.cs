using System;
using System.Collections.Generic;
using System.Text;

namespace DbService.Services
{
   public class SubCategoryDatatableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
