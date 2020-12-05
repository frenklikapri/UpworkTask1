using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UpworkTask.Data;
using UpworkTask.Data.Repositories;
using UpworkTask.Helpers;
using UpworkTask.Interfaces;

namespace UpworkTask.Infrastructure
{
    public class DIBuilder
    {
        /// <summary>
        /// Here we register the services in DI container
        /// </summary>
        public static void RegisterAutofac()
        {
            // get config
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();
            // register mvc controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());
            // register api controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            // register services
            builder.RegisterType<DataContext>();
            builder.RegisterInstance(AutoMapperConfiguration.CreateConfiguration()).As<MapperConfiguration>();
            builder.RegisterType<UsersRepository>().As<IUsersRepository>();
            builder.RegisterType<ProductsRepository>().As<IProductsRepository>();

            var container = builder.Build();
            Container = container;

            // set resolvers for mvc and api
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static IContainer Container { get; private set; }
    }
}