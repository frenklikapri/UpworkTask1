using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpworkTask.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string MaterialNumber { get; set; }

        public string EAN { get; set; }

        public string Specifications { get; set; }
    }
}