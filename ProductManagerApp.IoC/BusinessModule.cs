using Autofac;
using AutoMapper;
using ProductManagerApp.Business.Abstract;
using ProductManagerApp.Business.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.IoC
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<ProductImageManager>().As<IProductImageService>().InstancePerRequest();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<RoleManager>().As<IRoleService>().InstancePerRequest();
        }
    }
}
