using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagerApp.Web.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<ProductImagesDto> ProductsImages { get; set; }
    }
}