using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.DataAccess.Abstract
{
    public interface IProductImagesDal
    {
        IEnumerable<ProductImagesDto> GetAll();
        IEnumerable<ProductImagesDto> GetAllByProductId(int? productId);
        Task<ProductImagesDto> GetById(int? id);
        bool Insert(ProductImagesDto model);
        bool Update(ProductImagesDto model);
        bool Delete(int? id);
    }
}
