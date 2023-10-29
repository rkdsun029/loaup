using System.Web.Mvc;
// ----------------------------------------------------
// fileName : MainController.cs
// description : 놀이터 (쓸데없는데 알면 재미있는정보들)
// create : 2023-10-12 
// update :
// ----------------------------------------------------
namespace loaup_demo.Areas.Playground
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}