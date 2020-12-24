using ProductManagerApp.Data;
using ProductManagerApp.Entity;
using ProductManagerApp.Repository.Repositories;

namespace ProductManagerApp.Repository.Concrate
{
    public class ProductsRepository: BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductsRepository(ApplicationDbContext context) :base(context)
        {

        }
    }
}
