using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBooksManage.Startup))]
namespace WebBooksManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
