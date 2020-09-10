using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
   public  class Advertisment
    {
        public int Id { get; set; }
        [Required]
        public string  Title { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public int CountDays { get; set; }
        [Required]
        public string UriLink { get; set; }
     
        public string File { get; set; }

        public bool IsActive { get; set; }

    }
}
