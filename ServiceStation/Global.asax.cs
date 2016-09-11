using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Domain.Model;
using Ninject.Web.Mvc;
using ServiceStation.Infrastructure;


namespace ServiceStation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<CarContext>(new DropCreateDatabaseAlways<CarContext>());
            Database.SetInitializer(new CarDbInitializer());
            using (var context = new CarContext())
            {
                context.Database.Initialize(false);
            }

            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new NinjectDependecyResolver());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}
