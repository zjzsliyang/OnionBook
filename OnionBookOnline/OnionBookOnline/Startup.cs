using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnionBookOnline.Startup))]
namespace OnionBookOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
