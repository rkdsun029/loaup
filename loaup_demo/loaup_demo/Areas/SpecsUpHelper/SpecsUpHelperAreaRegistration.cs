using System.Web.Mvc;

namespace loaup_demo.Areas.SpecsUpHelper
{
    public class SpecsUpHelperAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SpecsUpHelper";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SpecsUpHelper_default",
                "SpecsUpHelper/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}