using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenEducator.Startup))]
namespace OpenEducator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
