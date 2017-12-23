using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductGroup
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        
    }
}