using Biblioteca_Softek.Data;
using Biblioteca_Softek.Interfaces;
using Biblioteca_Softek.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Biblioteca_Softek
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<BibliotecaDbContext, BibliotecaDbContext>( new Unity.Lifetime.HierarchicalLifetimeManager());

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILibroService,LibroService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}