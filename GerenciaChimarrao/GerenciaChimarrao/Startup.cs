using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerenciaChimarrao.Startup))]
namespace GerenciaChimarrao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
