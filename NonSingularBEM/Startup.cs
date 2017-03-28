using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NonSingularBEM.Startup))]
namespace NonSingularBEM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
