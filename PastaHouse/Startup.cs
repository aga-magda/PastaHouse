using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PastaHouse.Startup))]
namespace PastaHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
