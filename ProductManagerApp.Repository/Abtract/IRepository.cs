using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerApp.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetByIdAsync(int? id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int? id);
        int SaveChanges();
    }
}
