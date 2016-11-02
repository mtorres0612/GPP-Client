using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GPPClient.Startup))]
namespace GPPClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
