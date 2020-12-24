using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProductManagerApp.Business.Abstract;
using ProductManagerApp.Common.Helper;
using ProductManagerApp.Dto;

namespace ProductManagerApp.Cms.Controllers
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
             return View(_productService.GetAll().ToList());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDto productDto = await _productService.GetById(id);
            if (productDto == null)
            {
                return HttpNotFound();
            }
            return View(productDto);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductName,Barcode,Price,Detail,Count")] ProductDto productDto,IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                var id = _productService.Insert(productDto);
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        _productImageService.Insert(new ProductImagesDto { ImageByte = FileHelper.FileToByte(file), ImageSubText = file.FileName, ProductId = id });
                    }
                }
                
                return RedirectToAction("Index");
            }

            return View(productDto);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDto productDto = await _productService.GetById(id);
            if (productDto == null)
            {
                return HttpNotFound();
            }
            return View(productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,Barcode,Price,Detail,Count")] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(productDto);
                return RedirectToAction("Index");
            }
            return View(productDto);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDto productDto = await _productService.GetById(id);
            if (productDto == null)
            {
                return HttpNotFound();
            }
            return View(productDto);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
