using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaintShop.WebMVC.Startup))]
namespace PaintShop.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
