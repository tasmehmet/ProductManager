using Autofac;
using AutoMapper;
using ProductManagerApp.DataAccess.Abstract;
using ProductManagerApp.DataAccess.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.IoC
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDal>().As<IProductDal>().InstancePerRequest();
            builder.RegisterType<ProductImagesDal>().As<IProductImagesDal>().InstancePerRequest();
            builder.RegisterType<UserDal>().As<IUserDal>().InstancePerRequest();
            builder.RegisterType<RoleDal>().As<IRoleDal>().InstancePerRequest();
        }
    }
}
