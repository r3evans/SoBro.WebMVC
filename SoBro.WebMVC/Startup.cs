using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoBro.WebMVC.Startup))]
namespace SoBro.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
