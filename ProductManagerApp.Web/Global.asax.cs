using Autofac;
using Autofac.Integration.Mvc;
using ProductManagerApp.IoC;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductManagerApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerHttpRequest();
            AutoFacConfig.Run(builder);


        }
    }
}
