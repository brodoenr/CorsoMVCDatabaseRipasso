using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CorsoMVCDatabaseRipasso.Startup))]
namespace CorsoMVCDatabaseRipasso
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
