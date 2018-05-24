using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(D2Blog.Startup))]
namespace D2Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
