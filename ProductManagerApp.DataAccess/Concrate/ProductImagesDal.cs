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
    public class ProductImagesDal : IProductImagesDal
    {
        private readonly IProductImageRepository _productImagesRepository;
        private readonly IMapper _mapper;
        public ProductImagesDal(IProductImageRepository productImagesRepository, IMapper mapper)
        {
            _productImagesRepository = productImagesRepository;
            _mapper = mapper;
        }
        public bool Delete(int? id)
        {
            bool isOk = false;
            _productImagesRepository.Remove(id);
            _productImagesRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public IEnumerable<ProductImagesDto> GetAll()
        {
            var data = _productImagesRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductImagesDto>>(data);
        }

        public IEnumerable<ProductImagesDto> GetAllByProductId(int? productId)
        {
            var entityData = _productImagesRepository.GetAll().Select(x => x.ProductId == productId);
            return _mapper.Map<IEnumerable<ProductImagesDto>>(entityData);
        }

        public async Task<ProductImagesDto> GetById(int? id)
        {
            var data = await _productImagesRepository.GetByIdAsync(id);
            return _mapper.Map<ProductImagesDto>(data);
        }

        public bool Insert(ProductImagesDto model)
        {
            bool isOk = false;
            _productImagesRepository.Add(_mapper.Map<ProductImagesEntity>(model));
            _productImagesRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public bool Update(ProductImagesDto model)
        {
            bool isOk = false;
            _productImagesRepository.Update(_mapper.Map<ProductImagesEntity>(model));
            _productImagesRepository.SaveChanges();
            isOk = true;
            return isOk;
        }
    }
}
