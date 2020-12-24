using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Business.Abstract
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        Task<ProductDto> GetById(int? id);
        int Insert(ProductDto model);
        bool Update(ProductDto model);
        bool Delete(int? id);
    }
}
