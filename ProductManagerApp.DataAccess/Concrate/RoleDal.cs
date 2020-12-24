using AutoMapper;
using ProductManagerApp.DataAccess.Abstract;
using ProductManagerApp.Dto;
using ProductManagerApp.Entity;
using ProductManagerApp.Repository.Abtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.DataAccess.Concrate
{
    public class RoleDal : IRoleDal
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleDal(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public bool Delete(int? id)
        {
            bool isOk = false;
            _roleRepository.Remove(id);
            _roleRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public IEnumerable<RoleDto> GetAll()
        {
            var data = _roleRepository.GetAll();
            return _mapper.Map<IEnumerable<RoleDto>>(data);
        }

        public async Task<RoleDto> GetById(int? id)
        {
            var data = await _roleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleDto>(data);
        }

        public bool Update(RoleDto model)
        {
            bool isOk = false;
            _roleRepository.Update(_mapper.Map<RoleEntity>(model));
            _roleRepository.SaveChanges();
            isOk = true;
            return isOk;
        }
    }
}
