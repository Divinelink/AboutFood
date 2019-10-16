using AboutFood.Data.Services;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AboutFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryRestaurantData>()
                   .As<IRestaurantData>() // Whenever something needs IRestaurantData, this container should be able to handle it. 
                   .SingleInstance();

            var container = builder.Build(); //Whenever you need to resolve dependencies, use this container

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
            // Set the container as the DependencyResolver 
            // Anywhere this mvc5 uses dependency resolution to inject dependencies, the container can jump into action 


        }
    }
}