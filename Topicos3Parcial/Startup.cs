using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Topicos3Parcial.Startup))]
namespace Topicos3Parcial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
