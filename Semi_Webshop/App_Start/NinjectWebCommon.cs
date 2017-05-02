[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Semi_Webshop.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Semi_Webshop.App_Start.NinjectWebCommon), "Stop")]

namespace Semi_Webshop.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using services;
    using System;
    using System.Web;
    using System.Web.Configuration;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISettingsService>().To<SettingsService>().InSingletonScope();

            kernel.Bind<IMovieService>().ToMethod(context =>
            {
                string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
                string file = System.Text.RegularExpressions.Regex.Replace(WebConfigurationManager.AppSettings["product:path"],
                    @"\|DataDirectory\|", appDataPath, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return MovieService.Create(file);
            }).InSingletonScope();

        }

       
    }
}
