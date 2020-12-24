using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.DataAccess.Abstract
{
    public interface IUserDal
    {
        IEnumerable<UsersDto> GetAll();
        Task<UsersDto> GetById(int? id);
        UsersDto GetByMail(string email);
        bool Insert(UsersDto model);
        bool Update(UsersDto model);
        bool Delete(int? id);
        UsersDto LoginUser(string email,string password);
    }
}
