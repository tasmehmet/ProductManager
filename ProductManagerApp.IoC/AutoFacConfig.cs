using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ProductManagerApp.Business.Abstract;
using ProductManagerApp.Business.Concrate;
using ProductManagerApp.Common.AutoMapper;
using ProductManagerApp.Data;
using ProductManagerApp.DataAccess.Abstract;
using ProductManagerApp.DataAccess.Concrate;
using ProductManagerApp.Repository;
using ProductManagerApp.Repository.Concrate;
using ProductManagerApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductManagerApp.IoC
{
    public static class AutoFacConfig
    {
        public static void Run(ContainerBuilder builder)
        {
            SetAutofacContainer(builder);
        }

        private static void SetAutofacContainer(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();

            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new BusinessModule());
            builder.RegisterModule(new DataAccessModule());

            #region AutoMapperRegister
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion


            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
