using System.Web.Mvc;
// ----------------------------------------------------
// fileName : MainController.cs
// description : 구인/구직
// create : 2023-10-24
// update :
// ----------------------------------------------------
namespace loaup_demo.Areas.Wanted
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}