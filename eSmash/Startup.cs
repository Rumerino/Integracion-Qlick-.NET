using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eSmash.Startup))]
namespace eSmash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
