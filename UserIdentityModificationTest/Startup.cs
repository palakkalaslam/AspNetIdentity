using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserIdentityModificationTest.Startup))]
namespace UserIdentityModificationTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
