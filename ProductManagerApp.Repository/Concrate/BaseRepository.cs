using ProductManagerApp.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerApp.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual async Task<TEntity> GetByIdAsync(int? id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Remove(int? id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
