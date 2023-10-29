using System.Web.Mvc;

namespace loaup_demo.Areas.CharacterSearch
{
    public class CharacterSearchAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CharacterSearch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CharacterSearch_default",
                "CharacterSearch/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}