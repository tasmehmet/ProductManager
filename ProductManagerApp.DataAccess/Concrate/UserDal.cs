using AutoMapper;
using ProductManagerApp.DataAccess.Abstract;
using ProductManagerApp.Dto;
using ProductManagerApp.Entity;
using ProductManagerApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.DataAccess.Concrate
{
    public class UserDal : IUserDal
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserDal(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public bool Delete(int? id)
        {
            bool isOk = false;
            _userRepository.Remove(id);
            _userRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public IEnumerable<UsersDto> GetAll()
        {
            var data = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UsersDto>>(data);
        }

        public async Task<UsersDto> GetById(int? id)
        {
            var data = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UsersDto>(data);
        }

        public UsersDto GetByMail(string email)
        {
            var data = _userRepository.GetAll()?.FirstOrDefault(x=>x.Email == email);
            return _mapper.Map<UsersDto>(data);
        }

        public bool Insert(UsersDto model)
        {
            bool isOk = false;
            _userRepository.Add(_mapper.Map<UsersEntity>(model));
            _userRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public UsersDto LoginUser(string email, string password)
        {
            var data = _userRepository.GetAll()?.FirstOrDefault(x=>x.Email == email && x.Password == password);
            return _mapper.Map<UsersDto>(data);
        }

        public bool Update(UsersDto model)
        {
            bool isOk = false;
            _userRepository.Update(_mapper.Map<UsersEntity>(model));
            _userRepository.SaveChanges();
            isOk = true;
            return isOk;
        }
    }
}

