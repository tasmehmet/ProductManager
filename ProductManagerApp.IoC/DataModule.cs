using Autofac;
using ProductManagerApp.Data;
using ProductManagerApp.Repository.Abtract;
using ProductManagerApp.Repository.Concrate;
using ProductManagerApp.Repository.Repositories;

namespace ProductManagerApp.IoC
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>().InstancePerRequest();

            builder.RegisterType<ProductsRepository>().As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<ProductImageRepository>().As<IProductImageRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
        }
    }
}
