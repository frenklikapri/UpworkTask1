using Newtonsoft.Json;
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

        public List<ProductSpecificationsDto> SpecificationsDeserialized
        {
            get
            {
                if (string.IsNullOrEmpty(Specifications))
                    return new List<ProductSpecificationsDto>();

                var list = JsonConvert.DeserializeObject<List<ProductSpecificationsDto>>(Specifications);

                return list;
            }
        }
    }

    public class ProductSpecificationsDto
    {
        public List<ProductSpecificationsLanguageDto> ProductSpecificationsLanguages { get; set; }
    }

    public class ProductSpecificationsLanguageDto
    {
        public List<ProductLanguageDto> Languages { get; set; }
        public string SpecificationName { get; set; }

        //public string Height { get; set; }
        //public string Width { get; set; }
        //public string Depth { get; set; }
        //public string Length { get; set; }
        //public string Weight { get; set; }
        //public string Color { get; set; }
        //public string TemperatureResistances { get; set; }
        //public string Wattage { get; set; }
        //public string ManufacturerName { get; set; }
        //public string ManufacturerLocation { get; set; }
    }

    public class ProductLanguageDto
    {
        public string LanguageName { get; set; }
        public string Value { get; set; }
    }

    public class SaveProductResultDto
    {
        public bool Success { get; set; }
        public bool ProductExists { get; set; }
    }
}