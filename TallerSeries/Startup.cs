using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TallerSeries.Startup))]
namespace TallerSeries
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
