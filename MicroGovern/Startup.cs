using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MicroGovern.Startup))]
namespace MicroGovern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
