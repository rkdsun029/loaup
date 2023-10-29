using System.Web.Mvc;

namespace loaup_demo.Areas.Wanted
{
    public class WantedAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Wanted";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Wanted_default",
                "Wanted/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}