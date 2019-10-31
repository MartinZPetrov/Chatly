using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chatly.Startup))]
namespace Chatly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
