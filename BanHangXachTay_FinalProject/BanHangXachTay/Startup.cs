using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BanHangXachTay.Startup))]
namespace BanHangXachTay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
