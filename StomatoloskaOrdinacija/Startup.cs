using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StomatoloskaOrdinacija.Startup))]
namespace StomatoloskaOrdinacija
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
