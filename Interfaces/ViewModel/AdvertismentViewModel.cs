using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ViewModel
{
   public class AdvertismentViewModel
    {
        public Advertisment Advertisment { get; set; }

        public IFormFile File { get; set; }

        public string Error { get; set; }
    }
}
