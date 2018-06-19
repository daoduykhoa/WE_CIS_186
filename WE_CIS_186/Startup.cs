using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WE_CIS_186.Startup))]
namespace WE_CIS_186
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
