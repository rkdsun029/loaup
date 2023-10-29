using System.Web.Mvc;

namespace loaup_demo.Areas.ClassCategory
{
    public class ClassCategoryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ClassCategory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ClassCategory_default",
                "ClassCategory/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}