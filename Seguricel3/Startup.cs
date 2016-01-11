using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Seguricel3.Startup))]
namespace Seguricel3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}
