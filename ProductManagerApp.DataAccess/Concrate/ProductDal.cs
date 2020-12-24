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
    public class ProductDal : IProductDal
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper; 
        public ProductDal(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public bool Delete(int? id)
        {
            bool isOk = false;
            _productRepository.Remove(id);
            _productRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var data = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<ProductDto> GetById(int? id)
        {
            var data = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(data);
        }

        public int Insert(ProductDto model)
        {
            _productRepository.Add(_mapper.Map<ProductEntity>(model));
            _productRepository.SaveChanges();
            int id = GetAll().LastOrDefault().Id;
            return id;
        }

        public bool Update(ProductDto model)
        {
            bool isOk = false;
            _productRepository.Update(_mapper.Map<ProductEntity>(model));
            _productRepository.SaveChanges();
            isOk = true;
            return isOk;
        }
    }
}
