using ProductManagerApp.Data;
using ProductManagerApp.Entity;
using ProductManagerApp.Repository.Repositories;
using System.Collections.Generic;

namespace ProductManagerApp.Repository.Concrate
{
    public class ProductImageRepository: BaseRepository<ProductImagesEntity>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
