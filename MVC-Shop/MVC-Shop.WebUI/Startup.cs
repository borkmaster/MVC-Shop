using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Shop.WebUI.Startup))]
namespace MVC_Shop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
