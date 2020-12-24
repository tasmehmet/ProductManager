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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public bool Delete(int? id)
        {
            return _userDal.Delete(id);
        }

        public IEnumerable<UsersDto> GetAll()
        {
            return _userDal.GetAll();
        }

        public Task<UsersDto> GetById(int? id)
        {
            return _userDal.GetById(id);
        }

        public UsersDto GetByMail(string email)
        {
            return _userDal.GetByMail(email);
        }

        public bool Insert(UsersDto model)
        {
            return _userDal.Insert(model);
        }

        public UsersDto LoginUser(string email, string password)
        {
            return _userDal.LoginUser(email,password);
        }

        public bool Update(UsersDto model)
        {
            return _userDal.Update(model);
        }
    }
}
