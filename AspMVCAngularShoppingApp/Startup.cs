using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AngularDemo.Startup))]

namespace AngularDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
