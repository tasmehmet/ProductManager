using ProductManagerApp.Data;
using ProductManagerApp.Entity;
using ProductManagerApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Repository.Concrate
{
    public class UserRepository : BaseRepository<UsersEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
