using System.Web.Mvc;

namespace loaup_demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ActionFilter());
        }
    }

    public class ActionFilter : IActionFilter
    {
        public ActionFilter()
        { 
        
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //string _path = filterContext.HttpContext.Request.Path;
            //throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new System.NotImplementedException();
        }
    }
}
