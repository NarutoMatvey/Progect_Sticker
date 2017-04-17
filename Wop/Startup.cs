using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wop.Startup))]
namespace Wop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
