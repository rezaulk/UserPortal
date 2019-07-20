using AutoMapper;
using Microsoft.Practices.Unity;
using System;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc4;
using UserPortal.Core.Entities;
using UserPortal.Core.Infrastructure;
using UserPortal.Core.Services;
using UserPortal.Core.Services.Interfaces;
using UserPortal.Models;

namespace UserPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            IUnityContainer container = new UnityContainer();

            container.RegisterType<IUserPortalService, UserPortalService>();

            container.RegisterType<DbContext, UserPortalDbContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            Mapper.Initialize(conf =>
            {
                conf.CreateMap<RegistrationViewModel, User>();
                conf.CreateMap<User,RegistrationViewModel>();

                conf.CreateMap<LoginViewModel, User>();
                conf.CreateMap<User, LoginViewModel>();




            });
        }
    }
}
