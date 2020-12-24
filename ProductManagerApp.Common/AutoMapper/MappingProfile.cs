using AutoMapper;
using ProductManagerApp.Dto;
using ProductManagerApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<ProductImagesEntity, ProductImagesDto>().ReverseMap();
            CreateMap<UsersEntity, UsersDto>().ReverseMap();
            CreateMap<RoleEntity, RoleDto>().ReverseMap();
        }
    }
}
