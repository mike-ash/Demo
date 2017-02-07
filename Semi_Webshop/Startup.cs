using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Semi_Webshop.Startup))]
namespace Semi_Webshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
