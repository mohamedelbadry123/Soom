using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.ViewModel
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }

        public IFormFile Image { get; set; }

        public string Error { get; set; }
    }
}
