using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Softwire.WebUI.Startup))]
namespace Softwire.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
