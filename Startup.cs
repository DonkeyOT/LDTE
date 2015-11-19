using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LDTE_Web.Startup))]
namespace LDTE_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
