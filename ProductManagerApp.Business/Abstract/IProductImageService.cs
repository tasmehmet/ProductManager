using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Business.Abstract
{
    public interface IProductImageService
    {
        IEnumerable<ProductImagesDto> GetAll();
        Task<ProductImagesDto> GetById(int? id);
        bool Insert(ProductImagesDto model);
        bool Update(ProductImagesDto model);
        bool Delete(int? id);
    }
}
