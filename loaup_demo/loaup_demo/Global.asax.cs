using loaup_demo.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace loaup_demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // ������Ʈ ������ �о����
            new DataSheetUtil().LoadData();

            // https://lostark.game.onstove.com/Main ���ĸ���
        }
    }
}
