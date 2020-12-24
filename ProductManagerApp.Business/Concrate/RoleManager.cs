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
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public bool Delete(int? id)
        {
            return _roleDal.Delete(id);
        }

        public IEnumerable<RoleDto> GetAll()
        {
            return _roleDal.GetAll();
        }

        public Task<RoleDto> GetById(int? id)
        {
            return _roleDal.GetById(id);
        }

        public bool Update(RoleDto model)
        {
            return _roleDal.Update(model);
        }
    }
}
