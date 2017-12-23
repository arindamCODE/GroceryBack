using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductInfo
    {
        public int id { get; set; }

        public int groupID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public int rate { get; set; }
    }
}