using Autofac;
using Autofac.Integration.WebApi;
using DataAccessLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Assignment_6.App_Start
{
    public class AutoFacConfig
    {
        public static void Config()
        {

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UniteOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ContextFactory>().As<IContextFactory>().InstancePerRequest();
            builder.RegisterGeneric(typeof(MainRepo<>)).As(typeof(IMainRepo<>)) .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}