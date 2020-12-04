using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UpworkTask.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string MaterialNumber { get; set; }

        [Required]
        public string EAN { get; set; }

        public string Specifications { get; set; }
    }
}