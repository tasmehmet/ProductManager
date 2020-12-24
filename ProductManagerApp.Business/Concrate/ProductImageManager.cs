using ProductManagerApp.Business.Abstract;
using ProductManagerApp.DataAccess.Abstract;
using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Business.Concrate
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImagesDal _productImagesDal;
        public ProductImageManager(IProductImagesDal productImagesDal)
        {
            _productImagesDal = productImagesDal;
        }
        public bool Delete(int? id)
        {
            return _productImagesDal.Delete(id);
        }

        public IEnumerable<ProductImagesDto> GetAll()
        {
            return _productImagesDal.GetAll();
        }

        public Task<ProductImagesDto> GetById(int? id)
        {
            return _productImagesDal.GetById(id);
        }

        public bool Insert(ProductImagesDto model)
        {
            return _productImagesDal.Insert(model);
        }

        public bool Update(ProductImagesDto model)
        {
            return _productImagesDal.Update(model);
        }
    }
}
