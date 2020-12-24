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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public bool Delete(int? id)
        {
            return _productDal.Delete(id);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _productDal.GetAll();
        }

        public Task<ProductDto> GetById(int? id)
        {
            return _productDal.GetById(id);
        }

        public int Insert(ProductDto model)
        {
            return _productDal.Insert(model);
        }

        public bool Update(ProductDto model)
        {
            return _productDal.Update(model);
        }
    }
}
