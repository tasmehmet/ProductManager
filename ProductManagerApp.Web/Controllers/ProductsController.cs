using ProductManagerApp.Business.Abstract;
using ProductManagerApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagerApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;

        public ProductsController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }
        // GET: Products
        public ActionResult Index()
        {
            var productData = _productService.GetAll();
            var productImageData = _productImageService.GetAll();
            return View(new ProductsViewModel { Products = productData, ProductsImages=productImageData});
        }
    }
}