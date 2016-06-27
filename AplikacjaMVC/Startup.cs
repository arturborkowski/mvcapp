using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplikacjaMVC.Startup))]
namespace AplikacjaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
