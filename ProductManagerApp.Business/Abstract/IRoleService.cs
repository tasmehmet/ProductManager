using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Business.Abstract
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        Task<RoleDto> GetById(int? id);
        bool Update(RoleDto model);
        bool Delete(int? id);
    }
}
