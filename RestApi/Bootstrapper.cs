using System.Data.Entity;
using System.Web.Http;
using Microsoft.Practices.Unity;
using RestApi.BusinessLayer;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Models.Unit_of_Work;

namespace RestApi
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            //Database.SetInitializer<PatientContext>(new PatientInitialiser());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>(); 

            //Added by Gopal Ganeriwal
            //This is instantiate PatientContext class along with Services and Unit of Work classes
            container.RegisterType<IPatientServices, PatientServices>().RegisterType<IUnitofWork, UnitOfWork>(new HierarchicalLifetimeManager()).RegisterType<IDatabaseContext, PatientContext>();

            //This is instantiate InMemoryPatientContext class along with Services and Unit of Work classes
            //container.RegisterType<IPatientServices, PatientServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager()).RegisterType<IDatabaseContext, InMemoryPatientContext>();

            return container;
        }
    }
}