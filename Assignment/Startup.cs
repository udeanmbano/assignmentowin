using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesmanProductManagement.Startup))]
namespace SalesmanProductManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
