using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myFootball.Startup))]
namespace myFootball
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
