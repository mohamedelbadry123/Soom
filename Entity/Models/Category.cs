using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
   public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
   
        public string Image { get; set; }



        public ICollection<SubCategory> SubCategorys { get; set; }

        public Category()
        {
            SubCategorys = new Collection<SubCategory>();
        }

    }
}
