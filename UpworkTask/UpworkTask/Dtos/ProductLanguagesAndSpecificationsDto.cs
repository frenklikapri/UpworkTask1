using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UpworkTask.Entities;

namespace UpworkTask.Dtos
{
    public class ProductLanguagesAndSpecificationsDto
    {
        public List<ProductLanguage> Languages { get; set; }
        public List<ProductSpecification> Specifications { get; set; }
    }
}