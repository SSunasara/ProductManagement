using ProductManagement.Business;
using ProductManagement.Business.Manager;
using ProductManagement.Business.Manager.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<UnityResolver>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<IProductManager, ProductManager>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}